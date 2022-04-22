using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AnswersApp.ViewModels;

namespace AnswersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyQuestionsPage : ContentPage
    {

        AskViewModel askViewModel;
        public MyQuestionsPage()
        {
            InitializeComponent();

            BindingContext = askViewModel = new AskViewModel();

            // TODO: Hasta no tener usuario global, vamos a tener que quemar el Id del usuario,
            // En mi caso es el id 1006

            askViewModel.MyQuestion.UserId = 1006;

            //LstMyQuestions.ItemsSource = (System.Collections.IEnumerable) askViewModel.GetQlist();

            LoadQuestions();
        }



        public async void LoadQuestions()
        {
            var list = await askViewModel.GetQlist();
            LstMyQuestions.ItemsSource = list; 
        }
    }
}