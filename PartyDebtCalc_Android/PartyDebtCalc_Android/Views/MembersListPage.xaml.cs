using PartyDebtCalc_Android.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyDebtCalc_Android.Views
{
    public partial class MembersListPage : ContentPage
    {
        private MembersListViewModel MembersListVM {  get; set; }
        public MembersListPage()
        {
            InitializeComponent();

            MembersListVM = new MembersListViewModel()
            {
                Navigation = this.Navigation
            };

            BindingContext = MembersListVM;
        }
    }
}