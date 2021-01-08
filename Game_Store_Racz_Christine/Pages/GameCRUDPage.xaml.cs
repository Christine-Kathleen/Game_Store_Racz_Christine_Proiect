using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game_Store_Racz_Christine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameCRUDPage : ContentPage
    {
        public GameCRUDPage(User user)
        {
            var vm = new GameCRUDViewModel(user);
            this.BindingContext = vm;
            vm.DisplayGameAdded += () => DisplayAlert("Success", "The game was added!", "OK");
            vm.DisplayGameDeleted += () => DisplayAlert("Success", "The game was deleted!", "OK");
            vm.DisplayGameAlreadyInList += () => DisplayAlert("Error", "Game already exists!", "OK");
            InitializeComponent();
        }
    }
}