using MedicalFacilityConsumer2.Models;
using MedicalFacilityConsumer2.Services.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MedicalFacilityConsumer2.Services
{
    public class PolmedService : IMedicalFacilityService
    {
        static HttpClient client = new HttpClient();
        private static string _polmedUrl = "api/Polmed/terms";

        static PolmedService()
        {
            //client.BaseAddress = new Uri("https://asp-opal-api.azurewebsites.net/");
            client.BaseAddress = new Uri("https://localhost:44379/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<TermModel>> SearchAvailableTerms(VisitTermsRequestModel request)
        {
            
            //client.BaseAddress = new Uri("https://localhost:44379/");
            client.DefaultRequestHeaders.Accept.Clear();
            

            try
            {
                //HttpResponseMessage response = await client.GetAsync($"api/Luxmed/terms?dateFrom={ dateFrom.ToString("yyyy-MM-dd") }&dateTo={ toDate.ToString("yyyy-MM-dd") }&serviceId={ serviceId }");
                HttpResponseMessage response = await client.GetAsync($"{_polmedUrl }?dateFrom={ request.DateFrom.ToString("yyyy-MM-dd") }&dateTo={ request.DateTo.ToString("yyyy-MM-dd") }&specialisation={ request.Specialisation }");
                if (response.IsSuccessStatusCode)
                {
                    //https://stackoverflow.com/questions/10399324/where-is-httpcontent-readasasync
                    //nuget Microsoft.AspNet.WebApi.Client 
                    var list = await response.Content.ReadAsAsync<List<TermModel>>();
                    return list;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                //log error
                throw new Exception(ex.Message);
            }
            return new List<TermModel>();
        }
    }
}
