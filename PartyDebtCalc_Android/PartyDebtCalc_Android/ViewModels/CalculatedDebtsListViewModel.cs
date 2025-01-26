using PartyDebtCalc_Android.Models;
using PartyDebtCalc_Android.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PartyDebtCalc_Android.ViewModels
{
    public class CalculatedDebtsListViewModel
    {
        public IList<Debt> Debts { get; private set; }
        public INavigation Navigation { get; private set; }
        public ICommand SavePartyDebtsCommand { get; protected set; }
        public bool IsSaveButtonEnable { get; set; }

        public CalculatedDebtsListViewModel(IList<Debt> listOfDebtors, INavigation navigation, bool isSaveButtonEnable)
        {
            Debts = listOfDebtors;
            Navigation = navigation;
            IsSaveButtonEnable = isSaveButtonEnable;
            SavePartyDebtsCommand = new Command(SavePartyDebts, CanSave);
            
        }

        private bool CanSave() => IsSaveButtonEnable && Debts.Count > 0;
        public void SavePartyDebts()
        {
            if (Debts != null)
            {
                App.PartiesDB.SavePatry(Debts);
                this.Navigation.PopAsync();
            }
        }
    }
} 
