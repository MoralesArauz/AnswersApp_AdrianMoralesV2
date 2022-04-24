using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswersApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {
        UserViewModel viewModel;
        List<UserViewModel> users;
        public UserRegisterPage()
        {
            InitializeComponent();
            // Estamos anclando la vista con el viewModel respectivo
            BindingContext = viewModel = new UserViewModel();

            LoadUserRoles();
        }

        private void CmdCancelRegister(object sender, EventArgs e)
        {

        }

        private async void CmdRegisterUser(object sender, EventArgs e)
        {
            // TODO: Se deben validar datos mínimos, estructura del email, complejidad de contraseña

            bool R = await viewModel.AddUser(TxtUserName.Text.Trim(),
                                             TxtFirstName.Text.Trim(),
                                             TxtLastName.Text.Trim(),
                                             TxtPhoneNumber.Text.Trim(),
                                             TxtPassword.Text.Trim(),
                                             BackUpEmail.Text.Trim(),
                                             JobDescription.Text.Trim());
            if (R)
            {
                await DisplayAlert("!!!", "The user was added correctly!","OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong!", "OK");
            }


        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            TxtPassword.IsPassword = !SwSeePassword.IsToggled;
        }

        private async void LoadUserRoles()
        {
            var roles = await viewModel.MyUser.GetUserRoles();
            CboUserRole.ItemsSource = roles;
        }
    }
}