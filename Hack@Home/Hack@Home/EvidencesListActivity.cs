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
using HackAtHome.SAL.Evidences;
using HackAtHome.CustomAdapters.Adapters;

namespace Hack_Home
{
    [Activity(Label = "@string/ApplicationName")]
    public class EvidencesListActivity : Activity
    {
        Complex Data;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EvidencesListLayout);
            var lblUsuario = FindViewById<TextView>(Resource.Id.lblUsuario);
            lblUsuario.Text = Intent.GetStringExtra("NameParticipant");

            try
            {
                Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");
                if (Data == null)
                {
                    LoadEvidences(Intent.GetStringExtra("TokenParticipant"));
                }
                else
                {
                    var EvidenceList = FindViewById<ListView>(Resource.Id.listView1);
                    EvidenceList.Adapter = Data.Adapter;
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Error("HackAtHome", $"Mensaje: {ex.Message}. InnerExeption: {ex.InnerException.Message}");
            }


            FindViewById<ListView>(Resource.Id.listView1).ItemClick += (sender, e) =>
            {

                var ActivityIntent = new Android.Content.Intent(this, typeof(EvidenceDetailActivity));
                ActivityIntent.PutExtra("IdEvidence", Data.Evidences[e.Position].EvidenceID);
                ActivityIntent.PutExtra("TokenParticipant", Intent.GetStringExtra("TokenParticipant"));
                ActivityIntent.PutExtra("NameParticipant", Intent.GetStringExtra("NameParticipant"));
                ActivityIntent.PutExtra("TitleEvidence", Data.Evidences[e.Position].Title);
                ActivityIntent.PutExtra("StatusEvidence", Data.Evidences[e.Position].Status);
                StartActivity(ActivityIntent);
            };


        }

        private async void LoadEvidences(string Token)
        {
            var evidences = new Evidences();
            var evidencesList = await evidences.GetEvidencesAsync(Token);
            var EvidenceList = FindViewById<ListView>(Resource.Id.listView1);
            var ea = new EvidenceAdapter(this, evidencesList, Resource.Layout.EvidencesList, Resource.Id.textView1, Resource.Id.textView2);
            EvidenceList.Adapter = ea;
            Data = new Complex();
            Data.Adapter = ea;
            Data.Evidences = evidencesList;
            var FragmentTransaction = this.FragmentManager.BeginTransaction();
            FragmentTransaction.Add(Data, "Data");
            FragmentTransaction.Commit();

            
        }
    }
}