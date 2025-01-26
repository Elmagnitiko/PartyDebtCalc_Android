using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyDebtCalc_Android.PreviousPartiesDB
{
    [Table("Party")]
    public class PartyEntity
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
