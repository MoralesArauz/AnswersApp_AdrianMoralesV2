using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AnswersApp.Models
{
    public class Ask
    {
        const string CONTENT_TYPE = "Content-Type";
        const string MIME_TYPE = "application/json";
        RestRequest request { get; set; }

        public Ask()
        {
            Answers = new HashSet<Answer>();
            request = new RestRequest();
        }

        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; }
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string ImageUrl { get; set; }
        public string AskDetail { get; set; }

        public virtual AskStatus AskStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }


        // Esta función llama a la ruta GetQuestionsListByUserID(pUserID) que retorna un Json
        // que luego debemos convertir a clase (modelo) Ask

        public async Task<ObservableCollection<Ask>>  GetQuestionListByUser()
        {

            try
            {
                // Como esta ruta es un poco más compleja de consumir, ya que lleva una función con nombre y ademas dos
                // parámetros, lo más conveniente es formatearla por aparte y luego adjuntarla a Base URL(nnToAPI.ProductionRoute)
                // para obtener la ruta completa
                string routeSufix = string.Format("Asks/GetQuestionsListByUserID?pUserID={0}",
                                                    this.UserId);
                //string routeSufix = "Asks";
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);
                request = new RestRequest(FinalApiRoute, Method.Get);

                // Info de Seguridad del ApiKey
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                RestResponse response =  await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Ask>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
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
