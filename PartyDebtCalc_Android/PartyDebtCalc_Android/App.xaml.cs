using PartyDebtCalc_Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PartyDebtCalc_Android;
using System.IO;
using PartyDebtCalc_Android.PreviousPartiesDB;
using System.Globalization;

namespace PartyDebtCalc_Android
{
    public partial class App : Application
    {
        private const string _dataBaseName = "PreviousPartiesDB.db3";
        private static DataBaseHandler _partiesDB;
        public static DataBaseHandler PartiesDB
        {
            get
            {
                if(_partiesDB == null)
                {
                    _partiesDB = new DataBaseHandler(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _dataBaseName));
                }
                return _partiesDB;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
