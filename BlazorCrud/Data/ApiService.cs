using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blazorcrud.Data
{
    public class ApiService
    {
        private readonly HttpClient httpHelperclient; //initialize only in constructor readonly
        private string BaseURL { get; set; }
        public ApiService()
        {
            BaseURL = "https://localhost:44351/api/Employee/";
            httpHelperclient = new HttpClient();
        }

        public async void CreateEmployee(Employee employee)
        {
            var request = new HttpRequestMessage { 
               Method =  HttpMethod.Post, 
               RequestUri = new Uri(BaseURL + "AddEmployee"),
                Content = new StringContent(employee.ToJson(),Encoding.UTF8, "application/json") // to send data extension for json
                  
        };
              
            var response = await httpHelperclient.SendAsync(request);
           // return JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
            // return null;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var response = await httpHelperclient.GetAsync(BaseURL + "GetEmployee");
            var res = JsonConvert.DeserializeObject <IList<Employee>>(response.Content.ReadAsStringAsync().Result);
            return res.ToList();
        }
        public async void UpdateEmployee(Employee employee)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(BaseURL + "UpdateEmployee"),
                Content = new StringContent(employee.ToJson(), Encoding.UTF8, "application/json")
            };

            await httpHelperclient.SendAsync(request);
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var response = await httpHelperclient.GetAsync(new Uri(BaseURL + id));
            return JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result); 
        }
        public async Task<Employee> DeleteEmployee(int id)
        {
            var response = await httpHelperclient.DeleteAsync(new Uri(BaseURL + id));
            return JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
