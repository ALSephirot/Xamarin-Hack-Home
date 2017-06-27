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
using Android.Webkit;
using HackAtHome.SAL.Evidences;

namespace Hack_Home
{
    [Activity(Label = "@string/ApplicationName")]
    public class EvidenceDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EvidenceDetailLayout);
            FindViewById<TextView>(Resource.Id.lblNombreUsuario).Text = Intent.GetStringExtra("NameParticipant");
            FindViewById<TextView>(Resource.Id.lblTitleEvidence).Text = Intent.GetStringExtra("TitleEvidence");
            FindViewById<TextView>(Resource.Id.lblStatusEvidence).Text = Intent.GetStringExtra("StatusEvidence");
            LoadEvidence(Intent.GetStringExtra("TokenParticipant"), Intent.GetIntExtra("IdEvidence", 0));
        }

        private async void LoadEvidence(string Token, int EvidenceID)
        {
            var evidences = new Evidences();
            var evidence = await evidences.GetEvidenceByIDAsync(Token, EvidenceID);
            FindViewById<WebView>(Resource.Id.wvDescription).LoadDataWithBaseURL(null, evidence.Description, "text/html", "utf-8", null);
            Koush.UrlImageViewHelper.SetUrlDrawable(FindViewById<ImageView>(Resource.Id.imgEvidence), evidence.Url);
        }
    }
}