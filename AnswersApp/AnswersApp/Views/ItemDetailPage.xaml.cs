using AnswersApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnswersApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}