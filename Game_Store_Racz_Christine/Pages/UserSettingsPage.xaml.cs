﻿using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game_Store_Racz_Christine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettingsPage : ContentPage
    {
        public UserSettingsPage(User _user)
        {
            var vm = new UserSettingsViewModel(_user);
            this.BindingContext = vm;
            vm.DisplayDeletedAccount += () => DisplayAlert("Deletion", "Your account was deleted!", "OK");
            vm.DisplayNoPassword += () => DisplayAlert("Error", "Password cannot be empty!", "OK");
            vm.DisplayPasswordChanged += () => DisplayAlert("Success", "Password changed!", "OK");
            InitializeComponent();

        }
    }
}