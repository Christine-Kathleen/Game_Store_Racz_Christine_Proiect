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
    public partial class CategoryCreatePage : ContentPage
    {
        public CategoryCreatePage(Models.User user, Category cat=null )
        {
            {
                var vm = new CategoryCreateViewModel(user, cat);
                this.BindingContext = vm;
                vm.DisplayCategoryAdded += () => DisplayAlert("Success", "The category was added!", "OK");
                vm.DisplayCategoryModified += () => DisplayAlert("Success", "The category was modified!", "OK");
                vm.DisplayNoCategoryName += () => DisplayAlert("Error", "You must add a category name!", "OK");
                vm.DisplayCategoryAlreadyInList += () => DisplayAlert("Error", "This category already exists!", "OK");
                InitializeComponent();
            }
        }


    }
}