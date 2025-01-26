using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PartyDebtCalc_Android
{
    public class StringValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool),
                                                                  typeof(StringValidationBehavior), false);

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
            IsValid = !(string.IsNullOrEmpty(e.NewTextValue) || string.IsNullOrWhiteSpace(e.NewTextValue));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
