using PartyDebtCalc_Android.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartyDebtCalc_Android.Views
{
    public partial class MemberPage : ContentPage
    {
        public MemberViewModel ViewModel { get; private set; }

        public MemberPage(MemberViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            BindingContext = ViewModel;
        }
    }
}