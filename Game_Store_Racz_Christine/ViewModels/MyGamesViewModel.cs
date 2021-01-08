﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Game_Store_Racz_Christine.Droid.Pages;
using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.Pages;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Game_Store_Racz_Christine.ViewModels
{
   public class MyGamesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly User user;
        

        public ICommand AddGameSelectedCommand { protected set; get; }
        public ICommand ViewGameSelectedCommand { protected set; get; }
        public ICommand BackToMainPageCommand { protected set; get; }
       

        public MyGamesViewModel(User _user)
        {
            user = _user;
            AddGameSelectedCommand = new Command(OnAddNewGameClicked);
            ViewGameSelectedCommand = new Command(OnViewGameSelected);
            BackToMainPageCommand = new Command(OnBackToMainPage);
        }
        public void OnAddNewGameClicked()
        {
            GameCRUDPage Page = new GameCRUDPage(user);
            Application.Current.MainPage = Page;
        }
        public void OnViewGameSelected()
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


        /*async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as ShopList
                });
            }
        }*/
    }
}
