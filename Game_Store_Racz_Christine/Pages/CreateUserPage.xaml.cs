using Game_Store_Racz_Christine.Droid.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game_Store_Racz_Christine.Droid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUserPage : ContentPage
    {
        public CreateUserPage()
        { 
            var vm = new CreateUserViewModel();
            this.BindingContext = vm;
            vm.DisplayTakenEmail += () => DisplayAlert("Error", "This email address is already taken!", "OK"); //error alerts
            vm.DisplayInvalidEmail += () => DisplayAlert("Error", "This email address format is invalid!", "OK");
            vm.DisplayNoPassword+=()=> DisplayAlert("Error", "Password cannot be empty!", "OK");
            vm.DisplayUserCreated+=()=> DisplayAlert("Success", "The user was created!", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();//after completing the email field it focusses the password field
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.RegisterCommand.Execute(null);//it executes the register command
            };
        }
    }
}

