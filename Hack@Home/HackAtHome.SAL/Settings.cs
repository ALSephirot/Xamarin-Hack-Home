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

namespace HackAtHome.SAL
{
    public class Settings
    {
        public static string WebAPIBaseAddress {
            get {
                return "https://ticapacitacion.com/hackathome/";
            }
        }

        public static string AzureMobileServiceEndpoint
        {
            get
            {
                return @"http://xamarin-diplomado.azurewebsites.net/";
            }
        }
    }
}