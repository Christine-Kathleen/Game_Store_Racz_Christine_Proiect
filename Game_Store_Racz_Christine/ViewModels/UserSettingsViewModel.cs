﻿using Game_Store_Racz_Christine.Droid.Pages;
using Game_Store_Racz_Christine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;


namespace Game_Store_Racz_Christine.ViewModels
{
    public class UserSettingsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //private string email;
        private readonly User user;
        public Action DisplayDeletedAccount;
        public Action DisplayNoPassword;
        public Action DisplayPasswordChanged;

        public string Email
        {
            get { return user.Email; }
        }
        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewPassword"));
            }
        }

        public ICommand BackToMainPageCommand { protected set; get; }
        public ICommand DeleteAccountCommand { protected set; get; }
        public ICommand PasswordChangeCommand { protected set; get; }
        


        public UserSettingsViewModel(User _user)
        {
            user = _user;
            //email = user.Email;
            BackToMainPageCommand = new Command(OnBackToMainPage);
            DeleteAccountCommand = new Command(OnDeleteAccount);
            PasswordChangeCommand = new Command(OnPasswordChange);
        }
        public void OnBackToMainPage()
        {
            MainPage Page = new MainPage(user);
            Application.Current.MainPage = Page;
        }
       async public void OnDeleteAccount()
        {
            await App.Database.DeleteUserAsync(user);
            DisplayDeletedAccount();
            LoginPage Page = new LoginPage();
            Application.Current.MainPage = Page;
        }

        async public void OnPasswordChange()
        { 
            if (!string.IsNullOrEmpty(NewPassword)) 
            {
                user.Password = UserHelper.CreateMD5(NewPassword);
                await App.Database.SaveUpdateUserAsync(user);
                DisplayPasswordChanged();
            }
            else
            {
                DisplayNoPassword();
            }
        }

    }
}
