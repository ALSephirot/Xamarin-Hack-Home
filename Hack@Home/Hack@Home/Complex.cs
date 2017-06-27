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
using HackAtHome.CustomAdapters.Adapters;
using HackAtHome.Entities.models;

namespace Hack_Home
{
    public class Complex : Fragment
    {
        public EvidenceAdapter Adapter { get; set; }
        public List<Evidence> Evidences { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }
    }
}