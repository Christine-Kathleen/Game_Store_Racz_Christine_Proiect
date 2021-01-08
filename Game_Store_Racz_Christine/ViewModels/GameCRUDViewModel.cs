using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.Pages;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Game_Store_Racz_Christine.ViewModels
{
    public class GameCRUDViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //public event NotifyCollectionChangedEventHandler CollectionChanged= delegate { };

        public ICommand BackToMyGamesPageCommand { protected set; get; }
        public ICommand SaveButtonClickedCommand { protected set; get; }
        public ICommand DeleteButtonClickedCommand { protected set; get; }

        public Action DisplayGameAdded;
        public Action DisplayGameDeleted;
        public Action DisplayGameAlreadyInList;
        private string name;
        private readonly User user;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Categories"));
            }
        }
        public GameCRUDViewModel(User _user)
        {
            user = _user;
            BackToMyGamesPageCommand = new Command(OnGoToMyGames);
            SaveButtonClickedCommand = new Command(OnSaveButtonClicked);
            DeleteButtonClickedCommand = new Command(OnDeleteButtonClicked);
            GetCategories(user);
        }

        async public void GetCategories(User user)
        {
            await App.Database.SaveCategoryAsync(new Category() { CategoryName = "Puzzle", UserID = user.ID });
            Categories = await App.Database.GetCategorysAsync();
        }



        public void OnGoToMyGames()
        {
            MyGamesPage Page = new MyGamesPage(user);
            Application.Current.MainPage = Page;
        }
        async public void OnSaveButtonClicked()
        {
            await App.Database.SaveGameAsync(new Game() { Name = name, Description = description });
            DisplayGameAdded();
        }
        async public void OnDeleteButtonClicked()
        {
            //ait App.Database.DeleteGameAsync(name);
            DisplayGameDeleted();
            MyGamesPage Page = new MyGamesPage(user);
            Application.Current.MainPage = Page;
        }



    }
}

