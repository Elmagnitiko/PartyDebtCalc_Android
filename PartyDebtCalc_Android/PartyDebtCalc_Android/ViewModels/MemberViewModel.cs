using PartyDebtCalc_Android.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PartyDebtCalc_Android.ViewModels
{
    public class MemberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MembersListViewModel listViewModel;
        public Member Member { get; private set; }
        public MemberViewModel()
        {
            Member = new Member();
        }
        public MembersListViewModel ListViewModel
        {
            get => listViewModel;
            set
            {
                if (listViewModel != value)
                {
                    listViewModel = value;
                    OnPropertyChanged(nameof(ListViewModel));
                }
            }
        }
        public string Name
        {
            get => Member.Name;
            set
            {
                if (Member.Name != value)
                {
                    Member.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public decimal Spent
        {
            get => Member.Spent;
            set
            {
                if (Member.Spent != value)
                {
                    Member.Spent = value;
                    OnPropertyChanged(nameof(Spent));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
