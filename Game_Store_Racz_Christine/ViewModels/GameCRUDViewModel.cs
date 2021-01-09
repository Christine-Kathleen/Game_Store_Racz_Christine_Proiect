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

        public Action DisplayGameAdded;
        public Action DisplayGameAlreadyInList;
        public Action DisplayEmptyFields;
        public Action DisplayGameModified;

        private string name;
        private readonly User user;

        private Game editableGame;
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

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCategory"));
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
        public GameCRUDViewModel(User _user, Game game)            
        {
            editableGame = game;
            user = _user;
            BackToMyGamesPageCommand = new Command(OnGoToMyGames);
            SaveButtonClickedCommand = new Command(OnSaveButtonClicked);
             GetCategories(user);
        }

        async public void GetCategories(User user)
        {
            Categories = await App.Database.GetCategorysAsync(user.ID);

            if (editableGame != null)
            {
                SelectedCategory = categories.Find(cat => cat.ID == editableGame.CategoryID);
                Description = editableGame.Description;
                Name = editableGame.Name;
            }
        }
        public void OnGoToMyGames()
        {
            MyGamesPage Page = new MyGamesPage(user);
            Application.Current.MainPage = Page;
        }
        async public void OnSaveButtonClicked()
        {
            //edit
            if (editableGame != null)
            {
                List<Game> games = await App.Database.GetGamesAsync(user.ID);
                if (games.Exists(game => game.Name.ToUpper() == name.ToUpper() && game.ID!=editableGame.ID))
                {
                    DisplayGameAlreadyInList();
                }
                else if ((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrEmpty(Description)) && (selectedCategory != null))
                {
                    editableGame.CategoryID = selectedCategory.ID;
                    editableGame.Description = description;
                    editableGame.Name = name;
                    Game gm = new Game() { ID = editableGame.ID, CategoryID = editableGame.CategoryID, Description = editableGame.Description, Name = editableGame.Name, UserID = editableGame.UserID };
                    await App.Database.SaveGameAsync(gm);
                    DisplayGameModified();
                    //Name = "";
                    //Description = "";
                }
                else
                {
                    DisplayEmptyFields();
                }
            }
            //create
            else
            {
                List<Game> games = await App.Database.GetGamesAsync(user.ID);
                if (games.Exists(game => game.Name.ToUpper() == name.ToUpper()))
                {
                    DisplayGameAlreadyInList();
                }
                else if ((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrEmpty(Description)) && (selectedCategory != null))
                {
                    await App.Database.SaveGameAsync(new Game() { Name = name, Description = description, CategoryID = SelectedCategory.ID, UserID = user.ID });
                    DisplayGameAdded();
                    Name = "";
                    Description = "";
                }
                else
                {
                    DisplayEmptyFields();
                }
            }
        }
    }
}

