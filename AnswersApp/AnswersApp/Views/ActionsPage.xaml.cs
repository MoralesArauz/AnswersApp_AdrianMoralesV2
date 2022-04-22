using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionsPage : ContentPage
    {
        public ActionsPage()
        {
            InitializeComponent();
        }

        private async void BtnShowMyQuestions_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyQuestionsPage());
        }
    }
}