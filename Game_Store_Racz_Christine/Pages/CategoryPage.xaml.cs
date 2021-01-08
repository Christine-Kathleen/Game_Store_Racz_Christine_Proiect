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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage(User _user)
        {
            var vm = new CategoryViewModel(_user );
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}