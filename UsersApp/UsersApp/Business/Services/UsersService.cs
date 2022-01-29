using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Models;

namespace UsersApp.Business.Services
{
    public class UsersService
    {
        public async Task<ResponseModel> GetUsers()
        {
            string URL = "https://reqres.in/api/users";
            HttpClient client = new HttpClient();
            HttpResponseMessage response =  await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel>(content);
            }
            return null;
        }
    }
}
