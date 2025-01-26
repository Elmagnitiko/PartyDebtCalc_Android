using PartyDebtCalc_Android.Models;
using PartyDebtCalc_Android.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyDebtCalc_Android.Views
{
    public partial class CalculatedDebtsListPage : ContentPage
    {
        public CalculatedDebtsListViewModel CalculatedDebtsListVM { get; private set; }
        public CalculatedDebtsListPage(IList<Debt> membersDebts, INavigation navigation, bool isSaveButoonEnable)
        {
            InitializeComponent();

            CalculatedDebtsListVM = new CalculatedDebtsListViewModel(membersDebts, navigation, isSaveButoonEnable);
            BindingContext = CalculatedDebtsListVM;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync();
        }
    }
}