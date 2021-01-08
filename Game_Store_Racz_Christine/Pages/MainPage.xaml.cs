using Game_Store_Racz_Christine.Droid.ViewModels;
using Game_Store_Racz_Christine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game_Store_Racz_Christine.Droid.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(User _user)
        {
            var vm = new MainPageViewModel(_user);
            this.BindingContext = vm;
            InitializeComponent();
            
        }
    }
}
