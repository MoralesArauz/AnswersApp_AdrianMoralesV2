using AnswersApp.Services;
using AnswersApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage = new NavigationPage(new ActionsPage());
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
