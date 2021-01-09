using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Game_Store_Racz_Christine.Droid.Pages;
using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.Pages;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Game_Store_Racz_Christine.ViewModels
{
    public class CategoryCreateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand BackToCategoriesPageCommand { protected set; get; }
        public ICommand SaveButtonClickedCommand { protected set; get; }

        public Action DisplayCategoryAdded;
        public Action DisplayCategoryModified;
        public Action DisplayNoCategoryName;
        public Action DisplayCategoryAlreadyInList;
        private string categoryname;
        private readonly User user;


        
        public string CategoryName
        {
            get { return categoryname; }
            set
            {
                categoryname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CategoryName"));
            }
        }

        private Category category;
        public CategoryCreateViewModel(User _user, Category cat)
        {
            category = cat;
            //edit, assign categoryname to the property
            if (cat!=null)
            {
                CategoryName = cat.CategoryName;
            }
            user = _user;
            BackToCategoriesPageCommand = new Command(OnGoToMyCategories);
            SaveButtonClickedCommand = new Command(OnSaveButtonClicked);
        }
        public void OnGoToMyCategories()
        {
            CategoryPage Page = new CategoryPage(user);
            Application.Current.MainPage = Page;
        }
        async public void OnSaveButtonClicked()
        {
            //edit
            if (category != null)
            {
                if (!string.IsNullOrEmpty(CategoryName))
                {
                    category.CategoryName = categoryname;
                    await App.Database.SaveCategoryAsync(category);
                    DisplayCategoryModified();
                    //CategoryName = "";
                }
                else
                {
                    DisplayNoCategoryName();
                }
            }
            //create
            else
            {
                if (!string.IsNullOrEmpty(CategoryName))
                {
                    await App.Database.SaveCategoryAsync(new Category() { CategoryName = categoryname, UserID = user.ID });
                    DisplayCategoryAdded();
                    CategoryName = "";
                }
                else
                {
                    DisplayNoCategoryName();
                }
            }
        }
    }
}
