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
        public Action DisplayGameDeleted;


        public ICommand AddGameSelectedCommand { protected set; get; }
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
                if (value != null)
                {
                    EditDeleteEnabled = true;
                }
                else EditDeleteEnabled = false;
                selectedGame = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGame"));
            }
        }

        public MyGamesViewModel(User _user)
        {
            user = _user;
            AddGameSelectedCommand = new Command(OnAddNewGameClicked);
            BackToMainPageCommand = new Command(OnBackToMainPage);
            EditGameCommand = new Command(OnEditGame);
            DeleteGameCommand = new Command(OnDeleteGame);
            GetGames(user);
        }
        bool editDeleteEnabled;
        public bool EditDeleteEnabled
        {
            get { return editDeleteEnabled; }
            set
            {
                editDeleteEnabled = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EditDeleteEnabled"));
            }
        }
        public void OnEditGame()
        {
            Games = null;
            Game game = new Game() { ID = selectedGame.ID, CategoryID = selectedGame.CategoryID, Description = selectedGame.Description, Name = selectedGame.Name, UserID = selectedGame.UserID };
            selectedGame = null;
            GameCRUDPage Page = new GameCRUDPage(user, game);
            Application.Current.MainPage = Page;
        }
        async public void OnDeleteGame()
        {
            Game game=new Game() { ID = selectedGame.ID, CategoryID = selectedGame.CategoryID, Description = selectedGame.Description, Name = selectedGame.Name, UserID = selectedGame.UserID };
            selectedGame = null;
            int deletedcount=await App.Database.DeleteGameAsync(game);

            GetGames(user);
            selectedGame = null;
            DisplayGameDeleted();
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
        public void OnBackToMainPage()
        {
            MainPage Page = new MainPage(user);
            Application.Current.MainPage = Page;
        }

        //async void OnViewGameSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
                
        //    }
        //}


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
