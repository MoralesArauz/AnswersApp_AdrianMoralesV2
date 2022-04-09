using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnswersApp.Models;

namespace AnswersApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public User MyUser { get; set; }

        public Tools.Crypto MyCrypto { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyCrypto = new Tools.Crypto();

            //TODO: implementar los Command posteriormente
        }

        // Agregamos una funcion para AGREGAR el usuario.
        public async Task<bool> AddUser(string pUserName, string pFirstName, string pLastName,
                                        string pPhoneNumber, string pUserPassword, string pBackUpEmail,
                                        string pJobDescription, int pUserStatusID = 1, int pCountryID = 1,
                                        int pUserRoleID = 1)
        {
            if (IsBusy) return false;
            
            IsBusy = true;

            try
            {
                // TODO: Hay que encriptar el password
                MyUser.UserName = pUserName;
                MyUser.FirstName = pFirstName;
                MyUser.LastName = pLastName;
                MyUser.PhoneNumber = pPhoneNumber;

                // Se encripta la contraseña
                string encryptedPassword = MyCrypto.EncriptarEnUnSentido(pUserPassword);
                MyUser.UserPassword = encryptedPassword;



                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.JobDescription = pJobDescription;
                MyUser.UserStatusId = pUserStatusID;
                MyUser.CountryId = pCountryID;
                MyUser.UserRoleId = pUserRoleID;

                bool R = await MyUser.AddNewUser();

                return R;


            }
            catch (Exception)
            {
                return false;
            }
            finally { IsBusy = false; }
        }

        // Funcion para validar el permiso de acceso del usuario
        
        public async Task<bool> ValidateUserAccess(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy=true;
            try
            {
                string EncryptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyUser.UserName = pEmail;
                MyUser.UserPassword = EncryptedPassword;

                bool R = await MyUser.ValidateUserAccess();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
            finally
            {
                IsBusy = false;
            }



        }
    }
}
