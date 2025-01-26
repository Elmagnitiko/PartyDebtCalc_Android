using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyDebtCalc_Android.PreviousPartiesDB
{
    [Table("Debt")]
    public class DebtEntity
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("PartyID")]
        public Guid PartyID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("OwesTo")]
        public string OwesTo { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }
    }
}
