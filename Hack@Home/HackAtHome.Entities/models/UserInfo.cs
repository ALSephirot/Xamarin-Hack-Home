﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HackAtHome.Entities.models
{
    public class UserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string EventID { get; set; }
    }
}