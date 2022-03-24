using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AnswersApp.Models
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            Asks = new HashSet<Ask>();
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Likes = new HashSet<Like>();
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

            string FinalApiRoute = CnnToAPI.ProductionRoute + "users";

            var client = new RestClient(FinalApiRoute);

            var request = new RestRequest();
            request.Method = Method.Post;

            // Se debe agregar la info del ApiKey en el header
            request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            // Se serializa la clase junto con al información contenida en sus atributos(JSON)
            string SerializeClass = JsonConvert.SerializeObject(this);

            // Agregar la clase serializada al body del request

            request.AddParameter("application/json",SerializeClass, ParameterType.RequestBody);

            // Ahora ejecutamos la ruta del api
            RestResponse response = await client.ExecuteAsync(request);

            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.Created)
            {
                R= true;
            }

            return R;
        }

    }
}
