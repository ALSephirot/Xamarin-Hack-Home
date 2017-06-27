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
using Microsoft.WindowsAzure.MobileServices;
using HackAtHome.Entities.models;
using System.Threading.Tasks;

namespace HackAtHome.SAL.Authentication
{
    public class MicrosoftServiceClient
    {
        MobileServiceClient Client;

        private IMobileServiceTable<LabItem> LabItemTable;

        public async Task SendEvidence(LabItem userEvidence)
        {
            Client = new MobileServiceClient(Settings.AzureMobileServiceEndpoint);
            LabItemTable = Client.GetTable<LabItem>();
            await LabItemTable.InsertAsync(userEvidence);
        }
    }
}