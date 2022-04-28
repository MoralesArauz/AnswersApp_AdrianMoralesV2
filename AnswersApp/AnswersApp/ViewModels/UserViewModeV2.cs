using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnswersApp.Models;
using AnswersApp.Tools;
using Xamarin.Forms;

namespace AnswersApp.ViewModels
{
    public class UserViewModeV2 : BaseViewModel
    {
        // A diferencia de la primer versión del view model para usuario, este será adecuado
        // para realizar el binding a cada control en la vista

        // Con respecto a las propiedades, debemos usar el formato FULL PROP
        // ya que debemos implementar OnPropertyChange (cuya funcionalidad se hereda de BaseViewModel)

        // El binding entre los controles de la vista y las propiedades del viewmodel
        // ocurren en "tiempo real" al modificar los datos de la vista
        // para que esto ocurra debemos implementar OnPropChange en el get; o en el set;
        // de la propiedad

        private string correo;
        private string nombre;
        private string apellidos;
        private string numeroDeTelefono;
        private string contrasenia;
        private int contadorDeStrikes;
        private string correoDeRespaldo;
        private string descripcionDelEmpleo;
        private int idEstatudDeUsuario;
        private int idPais;
        private int idRolUsuario;

        public User MiUsuario { get; set; }

        Crypto MyEncriptador { get; set; }

        // A diferencia del vm original, acá definimos acciones por medio de Commands
        // Si la funcionalidad es muy compleja y requiere de un manejo más detallado, igual 
        // se puede usar en el vm original
        public Command AgregarUsuarioComand { get; }
        public UserViewModeV2()
        {
            MiUsuario = new User();
            MyEncriptador = new Crypto();

            // Implementación de los command
            AgregarUsuarioComand = new Command(async () => await 
                                   AgregarUsuario(Correo,Nombre,Apellidos,NumeroDeTelefono,
                                   Contrasenia,CorreoDeRespaldo,DescripcionDelEmpleo,1,1,1));

        }

        // Escribimos las funciones de forma similar (sino identica) a la versión original
        // del vm

        // Agregamos una funcion para AGREGAR el usuario.
        public async Task<bool> AgregarUsuario(string pUserName, string pFirstName, string pLastName,
                                        string pPhoneNumber, string pUserPassword, string pBackUpEmail,
                                        string pJobDescription, int pUserStatusID = 1, int pCountryID = 1,
                                        int pUserRoleID = 1)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                // TODO: Hay que encriptar el password
                MiUsuario.UserName = pUserName;
                MiUsuario.FirstName = pFirstName;
                MiUsuario.LastName = pLastName;
                MiUsuario.PhoneNumber = pPhoneNumber;

                // Se encripta la contraseña
                string encryptedPassword = MyEncriptador.EncriptarEnUnSentido(pUserPassword);
                MiUsuario.UserPassword = encryptedPassword;



                MiUsuario.BackUpEmail = pBackUpEmail;
                MiUsuario.JobDescription = pJobDescription;
                MiUsuario.UserStatusId = pUserStatusID;
                MiUsuario.CountryId = pCountryID;
                MiUsuario.UserRoleId = pUserRoleID;

                MiUsuario.UserRole = null;

                bool R = await MiUsuario.AddNewUser();

                return R;


            }
            catch (Exception)
            {
                return false;
            }
            finally { IsBusy = false; }
        }


        public int IdRolUsuario
        {
            get { return idRolUsuario; }
            set 
            {
                if (idRolUsuario == value)
                {
                    return;
                }
                idRolUsuario = value; 
                OnPropertyChanged(nameof(IdRolUsuario));
            }
        }


        public int IDPais
        {
            get { return idPais; }
            set
            {
                if (idPais == value)
                {
                    return;
                }
                idPais = value; 
                OnPropertyChanged(nameof(IDPais));
            }
        }


        public int IdEstatudDeUsuario
        {
            get { return idEstatudDeUsuario; }
            set 
            {
                if (idEstatudDeUsuario == value)
                {
                    return;
                }
                idEstatudDeUsuario = value; 
                OnPropertyChanged(nameof(IdEstatudDeUsuario));
            }
        }


        public string DescripcionDelEmpleo
        {
            get { return descripcionDelEmpleo; }
            set
            {
                if (descripcionDelEmpleo == value)
                {
                    return;
                }
                descripcionDelEmpleo = value; 
                OnPropertyChanged(nameof(DescripcionDelEmpleo));
            }
        }


        public string CorreoDeRespaldo
        {
            get { return correoDeRespaldo; }
            set
            {
                if (correoDeRespaldo == value)
                {
                    return;
                }
                correoDeRespaldo = value; 
                OnPropertyChanged(nameof(CorreoDeRespaldo));
            }
        }


        public int ContadorDeStrikes
        {
            get { return contadorDeStrikes; }
            set 
            {
                if (contadorDeStrikes == value)
                {
                    return;
                }
                contadorDeStrikes = value; 
                OnPropertyChanged(nameof(ContadorDeStrikes));
            }
        }


        public string Contrasenia
        {
            get { return contrasenia; }
            set 
            {
                if (contrasenia == value)
                {
                    return;
                }
                contrasenia = value;
                OnPropertyChanged(nameof(Contrasenia));
            }
        }


        public string NumeroDeTelefono
        {
            get { return numeroDeTelefono; }
            set 
            {
                if (numeroDeTelefono ==value)
                {
                    return;
                }
                numeroDeTelefono = value; 
                OnPropertyChanged(nameof(NumeroDeTelefono));
            }
        }


        public string Nombre 
        {
            get { return nombre; }
            set 
            {
                if (nombre == value)
                {
                    return;
                }
                nombre = value; 
                OnPropertyChanged(nameof(Nombre));

            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (apellidos == value)
                {
                    return;
                }
                apellidos = value; 
                OnPropertyChanged(nameof(Apellidos));
            }
        }


        public string Correo
        {
            get { return correo; }
            set
            {
                if (correo == value)
                {
                    return;
                }

                correo = value;
                OnPropertyChanged(nameof(correo));
            }

        }



    }
}
