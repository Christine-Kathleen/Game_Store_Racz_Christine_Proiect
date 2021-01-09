using Game_Store_Racz_Christine.Models;
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
    public partial class MyGamesPage : ContentPage
    {
        public MyGamesPage(User _user)
        {
            var vm = new MyGamesViewModel(_user);
            this.BindingContext = vm;
            vm.DisplayGameDeleted += () => DisplayAlert("Success", "The game was deleted!", "OK");
            InitializeComponent();
        }
    }
}