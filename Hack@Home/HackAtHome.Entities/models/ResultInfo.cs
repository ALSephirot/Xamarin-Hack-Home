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
using HackAtHome.Entities.enumerators;

namespace HackAtHome.Entities.models
{
    public class ResultInfo
    {
        public Status Status { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
    }
}