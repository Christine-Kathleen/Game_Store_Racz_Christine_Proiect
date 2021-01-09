using Game_Store_Racz_Christine.Droid.Pages;
using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Game_Store_Racz_Christine.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly User user;
        public Action DisplayCategoryDeleted;


        public ICommand AddCategorySelectedCommand { protected set; get; }
        public ICommand BackToMainPageCommand { protected set; get; }
        public ICommand EditCategoryCommand { protected set; get; }
        public ICommand DeleteCategoryCommand { protected set; get; }


        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (value!=null)
                {
                    EditDeleteEnabled = true;
                } else EditDeleteEnabled = false;
                selectedCategory = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCategory"));
            }
        }

        bool editDeleteEnabled;
        public bool EditDeleteEnabled
        {
            get { return editDeleteEnabled ; }
            set
            {
                editDeleteEnabled = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EditDeleteEnabled"));
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Categories"));
            }
        }
        public CategoryViewModel(User _user)
        {
            user = _user;
            AddCategorySelectedCommand = new Command(OnAddNewCategoryClicked);
            BackToMainPageCommand = new Command(OnBackToMainPage);
            EditCategoryCommand = new Command(OnEditCategory);
            DeleteCategoryCommand = new Command(OnDeleteCategory);
            GetCategories(user);
        }
        async public void OnDeleteCategory()
        {
            await App.Database.DeleteCategoryAsync(selectedCategory);
            GetCategories(user);
            SelectedCategory = null;
            DisplayCategoryDeleted();
        }
        public void OnEditCategory()
        {
                CategoryCreatePage Page = new CategoryCreatePage(user, SelectedCategory);
                Application.Current.MainPage = Page;
        }
        async public void GetCategories(User user)
        {
           Categories = await App.Database.GetCategorysAsync(user.ID);
        }

        public void OnAddNewCategoryClicked()
        {
            CategoryCreatePage Page = new CategoryCreatePage(user);
            Application.Current.MainPage = Page;
        }
        public void OnBackToMainPage()
        {
            MainPage Page = new MainPage(user);
            Application.Current.MainPage = Page;
        }
    }
}
