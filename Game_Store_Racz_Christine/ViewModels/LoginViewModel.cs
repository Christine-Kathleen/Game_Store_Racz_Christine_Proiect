
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Game_Store_Racz_Christine.Droid.ViewModels;
using Game_Store_Racz_Christine.Models;
using Game_Store_Racz_Christine.Droid.Pages;
using System.Text.RegularExpressions;

namespace Game_Store_Racz_Christine.Droid.ViewModels


{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayNoPassword;
        public Action DisplayInvalidEmail;
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Regex regexemail = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$");
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }
        public ICommand CreateUserCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            CreateUserCommand = new Command(OnCreateUserCommand);
        }
        async public void OnSubmit()
        {
            if (!regexemail.IsMatch(email.ToUpper()))
            {
                DisplayInvalidEmail();
            }
            else if (string.IsNullOrEmpty(password))
            {
                DisplayNoPassword();
            }
            else
            {
                User user = await App.Database.GetUserAsync(email, UserHelper.CreateMD5(password));
                if (user == null)
                {
                    DisplayInvalidLoginPrompt();
                }
                else
                {
                    MainPage Page = new Game_Store_Racz_Christine.Droid.Pages.MainPage(user);
                    Application.Current.MainPage = Page;
                }
            }

        }
        public void OnCreateUserCommand()
        {
            CreateUserPage Page = new Game_Store_Racz_Christine.Droid.Pages.CreateUserPage();// creates a local variable page of type createuserpage
            Application.Current.MainPage = Page;//sets the root page of the application to the current user page
        }
    }
}
