using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PartyDebtCalc_Android
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), 
                                                                  typeof(NumericValidationBehavior), false);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, @"^\d{1,9}([.,]\d{1,2})?$|^\d{9}$"));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
