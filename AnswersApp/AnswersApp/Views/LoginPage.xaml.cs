using AnswersApp.ViewModels;
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
    public partial class LoginPage : ContentPage
    {

        UserViewModel Vm;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new UserViewModel();
        }

        private async void CmdUserRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegisterPageV2());
        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            TxtPassword.IsPassword = !SwSeePassword.IsToggled;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = await Vm.ValidateUserAccess(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());

            if (R)
            {
                // Quitar este mensaje
                //await DisplayAlert(":)", "Usuario Correcto", "OK");

                await Navigation.PushAsync(new ActionsPage());
            }
            else
            {
                await DisplayAlert(":(", "Error de credenciales", "Ok");
                TxtPassword.Focus();
                
            }
        }
    }
}