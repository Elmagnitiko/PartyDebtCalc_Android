using PartyDebtCalc_Android.PreviousPartiesDB;
using PartyDebtCalc_Android.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PartyDebtCalc_Android.ViewModels
{
    public class PreviousPartiesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<PartyEntity> PreviousParties { get => App.PartiesDB.GetAllParties(); }
        public INavigation Navigation { get; set; }

        private const bool _isSaveButtonEnable = false;

        private PartyEntity _selectedParty;

        public PartyEntity SelectedParty
        {
            get => _selectedParty;
            set
            {
                if (_selectedParty != value)
                {
                    PartyEntity tempParty = value;
                    _selectedParty = null;
                    OnPropertyChanged(nameof(SelectedParty));
                    var id = tempParty.ID;
                    var debts = App.PartiesDB.GetPartyDebtsData(id);
                    Navigation.PushAsync(new CalculatedDebtsListPage(debts, this.Navigation, _isSaveButtonEnable));
                }
            }
        }
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }   
    }
}
