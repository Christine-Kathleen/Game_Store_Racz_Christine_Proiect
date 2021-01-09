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
        public GameCRUDPage(User user, Game game=null)
        {
            var vm = new GameCRUDViewModel(user, game);
            this.BindingContext = vm;
            vm.DisplayGameAdded += () => DisplayAlert("Success", "The game was added!", "OK");
            vm.DisplayGameModified += () => DisplayAlert("Success", "The game was modified!", "OK");
            vm.DisplayGameAlreadyInList += () => DisplayAlert("Error", "Game already exists!", "OK");
            vm.DisplayEmptyFields += () => DisplayAlert("Error", "All fields must be completed!", "OK");
            InitializeComponent();
            
        }
    }
}