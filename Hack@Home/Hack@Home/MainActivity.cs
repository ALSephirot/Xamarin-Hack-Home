using Android.App;
using Android.Widget;
using Android.OS;
using HackAtHome.SAL.Authentication;
using HackAtHome.Entities.enumerators;
using HackAtHome.Entities.models;

namespace Hack_Home
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ValidateButton = FindViewById<Button>(Resource.Id.button1);

            ValidateButton.Click += (sender, e) => {
                var Email = FindViewById<EditText>(Resource.Id.txtEmail);
                var Password = FindViewById<EditText>(Resource.Id.txtPassword);
                Validate(Email.Text, Password.Text);
            };
        }

        private async void Validate(string email, string password)
        {
            var auth = new Authenticate();
            var result = await auth.AuthenticateAsync(email, password);
            if(result.Status == Status.Success)
            {
                var MicrosoftEvidence = new LabItem()
                {
                    Email = email,
                    Lab = "Hack@Home",
                    DeviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId)
                };
                var MicrosotClient = new MicrosoftServiceClient();
                await MicrosotClient.SendEvidence(MicrosoftEvidence);

                var ActivityIntent = new Android.Content.Intent(this, typeof(EvidencesListActivity));
                ActivityIntent.PutExtra("NameParticipant", result.FullName);
                ActivityIntent.PutExtra("TokenParticipant", result.Token);
                StartActivity(ActivityIntent);
            }
            else
            {
                var mensaje = "";

                switch (result.Status)
                {
                    case Status.Error:
                        mensaje = "Error al autenticar, por favor verifica los datos.";
                        break;
                    case Status.InvalidUserOrNotInEvent:
                        mensaje = "Usuario inválido o no registrado en el curso.";
                        break;
                    case Status.OutOfDate:
                        mensaje = "El curso ya no se encuentra disponible.";
                        break;
                }

                var Builder = new AlertDialog.Builder(this);
                var Alert = Builder.Create();
                Alert.SetTitle(Resource.String.AlertLoginFailedTitleText);
                Alert.SetMessage(mensaje);
                Alert.SetButton("Ok", (sender, e) => { });
                Alert.Show();
            }
        }
    }
}

