using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game_Store_Racz_Christine.Droid.ViewModels;
using Game_Store_Racz_Christine.Data;
using System.IO;
using Game_Store_Racz_Christine.Models;

namespace Game_Store_Racz_Christine
{
    public partial class App : Application
    {
        static GameStoreDataBase database;
        public static GameStoreDataBase Database
        {
            get
            {
                if (database == null)//no data in the database
                {
                    database = new GameStoreDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new Game_Store_Racz_Christine.Droid.Pages.LoginPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
