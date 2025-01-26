using PartyDebtCalc_Android.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyDebtCalc_Android.Views
{
    public partial class PreviousPartiesList : ContentPage
    {
        private PreviousPartiesViewModel PreviousPartiesVM { get; set; }
        
        public PreviousPartiesList()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PreviousPartiesVM = new PreviousPartiesViewModel()
            {
                Navigation = this.Navigation,
            };

            BindingContext = PreviousPartiesVM;

            base.OnAppearing();
        }
    }
}