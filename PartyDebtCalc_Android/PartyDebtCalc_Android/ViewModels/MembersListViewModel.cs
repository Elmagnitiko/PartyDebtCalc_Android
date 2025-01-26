using PartyDebtCalc_Android.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PartyDebtCalc_Android.ViewModels
{
    public class MembersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MemberViewModel> Members { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateMemberCommand { get; protected set; }
        public ICommand DeleteMemberCommand { get; protected set; }
        public ICommand SaveMemberCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }
        public ICommand CalculateDebtsCommand { get; protected set; }

        private MemberViewModel selectedMember;
        public INavigation Navigation { get; set; }

        public MembersListViewModel()
        {
            Members = new ObservableCollection<MemberViewModel>();
            CreateMemberCommand = new Command(CreateMember);
            DeleteMemberCommand = new Command(DeleteMember);
            SaveMemberCommand = new Command(SaveMember);
            BackCommand = new Command(Back);
            CalculateDebtsCommand = new Command(CalculateDebts);
        }

        public MemberViewModel SelectedMember
        {
            get => selectedMember;
            set
            {
                if (selectedMember != value)
                {
                    MemberViewModel tempMember = value;
                    selectedMember = null;
                    OnPropertyChanged(nameof(SelectedMember));
                    Navigation.PushAsync(new MemberPage(tempMember));
                }
            }
        }

        private async void Back()
        {
            await Navigation.PopAsync();
        }

        private void SaveMember(object memberObject)
        {
            MemberViewModel member = memberObject as MemberViewModel;
            if (member != null && !Members.Contains(member))
            {
                Members.Add(member);
            }

            Back();
        }

        private void DeleteMember(object memberObject)
        {
            MemberViewModel member = memberObject as MemberViewModel;
            if (member != null)
            {
                Members.Remove(member);
            }

            Back();
        }

        private async void CreateMember()
        {
            await Navigation.PushAsync(new MemberPage(new MemberViewModel()
            {
                ListViewModel = this
            }));
        }

        private void CalculateDebts()
        {
            if (Members.Count > 0)
            {
                var calculatedList = DebtCalculator.CalculateDebts(Members);

                Navigation.PushAsync(new CalculatedDebtsListPage(calculatedList, this.Navigation, true));
                Members.Clear();
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
