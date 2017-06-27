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
using System.Net;
using Newtonsoft.Json;

namespace HackAtHome.SAL.Evidences
{
    public class Evidences
    {
        public async Task<List<Evidence>> GetEvidencesAsync(string token)
        {
            var Evidences = (List<Evidence>)null;

            var URI = $"{Settings.WebAPIBaseAddress}api/evidence/getevidences?token={token}";

            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var Response = await client.GetAsync(URI);
                    if(Response.StatusCode == HttpStatusCode.OK)
                    {
                        var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                        Evidences = JsonConvert.DeserializeObject<List<Evidence>>(ResultWebAPI);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return Evidences;
        }

        public async Task<EvidenceDetail> GetEvidenceByIDAsync(string token, int evidenceID)
        {
            var evidence = new EvidenceDetail();

            var URI = $"{Settings.WebAPIBaseAddress}api/evidence/getevidencebyid?token={token}&&evidenceid={evidenceID}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var Response = await client.GetAsync(URI);
                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                        evidence = JsonConvert.DeserializeObject<EvidenceDetail>(ResultWebAPI);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return evidence;
        }
    }
}