using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using HackAtHome.Entities.models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HackAtHome.SAL.Authentication
{
    public class Authenticate
    {
        public async Task<ResultInfo> AuthenticateAsync(string Email, string Password)
        {
            var Result = (ResultInfo) null;
            
            string EventID = "xamarin30";
            string RequestUri = "api/evidence/Authenticate";

            var User = new UserInfo() {
                Email = Email,
                Password = Password,
                EventID = EventID
            };

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.WebAPIBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var JSONUserInfo = JsonConvert.SerializeObject(User);

                    var Response = await client.PostAsync(RequestUri, new StringContent(JSONUserInfo.ToString(), Encoding.UTF8,"application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();

                    Result = JsonConvert.DeserializeObject<ResultInfo>(ResultWebAPI);
                }
                catch (Exception ex)
                {

                }
            }

            return Result;
        }
    }
}