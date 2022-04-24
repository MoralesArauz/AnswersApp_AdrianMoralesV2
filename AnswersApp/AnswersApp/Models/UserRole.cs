using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnswersApp.Models
{
    public class UserRole
    {

        const string CONTENT_TYPE = "Content-Type";
        const string MIME_TYPE = "application/json";
        RestRequest request { get; set; }


        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; }

        public virtual ICollection<User> Users { get; set; }


        public async Task<List<UserRole>> GetUserRolesList()
        {
            try
            {
                string routeSufix = "UserRoles/GetUserSelectableRolesList";
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);

                // Info de Seguridad del ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var UserRolesList = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return UserRolesList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
    }
}
