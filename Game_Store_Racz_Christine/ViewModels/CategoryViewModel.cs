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


        public ICommand AddCategorySelectedCommand { protected set; get; }
        public ICommand ViewGameSelectedCommand { protected set; get; }
        public ICommand BackToMainPageCommand { protected set; get; }


        public CategoryViewModel(User _user)
        {
            user = _user;
            AddCategorySelectedCommand = new Command(OnAddNewCategoryClicked);
            ViewGameSelectedCommand = new Command(OnViewCategorySelected);
            BackToMainPageCommand = new Command(OnBackToMainPage);
        }
        public void OnAddNewCategoryClicked()
        {
            GameCRUDPage Page = new GameCRUDPage(user);
            Application.Current.MainPage = Page;
        }
        public void OnViewCategorySelected()
        {
            GameCRUDPage Page = new GameCRUDPage(user);
            Application.Current.MainPage = Page;
        }
        public void OnBackToMainPage()
        {
            MainPage Page = new MainPage(user);
            Application.Current.MainPage = Page;
        }

        async void OnViewGameSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

            }
        }
    }
}
