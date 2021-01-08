using System;
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
        public ICommand EditGameCommand { protected set; get; }
        public ICommand DeleteGameCommand { protected set; get; }

        private List<Game> games;
        public List<Game> Games
        {
            get { return games; }
            set
            {
                games = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Games"));
            }
        }
        private Game selectedGame;
        public Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGame"));
            }
        }

        public MyGamesViewModel(User _user)
        {
            user = _user;
            AddGameSelectedCommand = new Command(OnAddNewGameClicked);
            ViewGameSelectedCommand = new Command(OnViewGameSelected);
            BackToMainPageCommand = new Command(OnBackToMainPage);
            EditGameCommand = new Command(OnEditGame);
            DeleteGameCommand = new Command(OnDeleteGame);
            GetGames(user);
        }
        public void OnEditGame()
        {
            GameCRUDPage Page = new GameCRUDPage(user);
            Application.Current.MainPage = Page;
        }
        async public void OnDeleteGame()
        {
            await App.Database.DeleteGameAsync(selectedGame);
            GetGames(user);
        }
        async public void GetGames(User user)
        {
            Games = await App.Database.GetGamesAsync(user.ID);
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
