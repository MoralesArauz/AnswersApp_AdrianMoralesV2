using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AnswersApp.Models
{
    public partial class User
    {

        public RestRequest request { get; set; }
        const string minetype = "application/json";
        const string CONTENT_TYPE = "Content-Type";

        public User()
        {
            Answers = new HashSet<Answer>();
            Asks = new HashSet<Ask>();
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Likes = new HashSet<Like>();

            request = new RestRequest();
        }



        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; }
        public string JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Like> Likes { get; set; }


        public async Task<bool> AddNewUser()
        {

            bool R = false;

            try
            {
                //  Se adjunta a la url base la direccion del recurso que queremos consumir
                string FinalApiRoute = CnnToAPI.ProductionRoute + "users";

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                

                // Agregar la info de seguridad, en este caso la api key
                request.AddHeader(CnnToAPI.ApiKeyName,CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, minetype);

                // Serializar la clase a json, pasarla en el body
                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass,minetype);

                // Esto lo envá la consulta al api y recube una respuesta que debemos
                // leer
                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }

            return R;
        }

        // Funcion para validar el acceso del usuario en el sistema

        public async Task<bool> ValidateUserAccess()
        {
            bool R = false;

            try
            {
                // Como esta ruta es un poco más compleja de consumir, ya que lleva una función con nombre y ademas dos
                // parámetros, lo más conveniente es formatearla por aparte y luego adjuntarla a Base URL(nnToAPI.ProductionRoute)
                // para obtener la ruta completa
                string routeSufix = string.Format("Users/ValidateUserLogin?pEmail={0}&pPassword={1}",
                                                    this.UserName,this.UserPassword);

                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);

                // Info de Seguridad del ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, minetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

            return R;
        }


    }
}
