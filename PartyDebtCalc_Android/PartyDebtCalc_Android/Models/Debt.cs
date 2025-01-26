using System;
using System.Collections.Generic;
using System.Text;

namespace PartyDebtCalc_Android.Models
{
    public class Debt
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> Owes { get; set; }
    }
}
