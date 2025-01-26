using PartyDebtCalc_Android.Models;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PartyDebtCalc_Android.PreviousPartiesDB
{
    public class DataBaseHandler
    {
        public readonly SQLiteConnection _db;
        public DataBaseHandler(string connctionString)
        {
            _db = new SQLiteConnection(connctionString);
            _db.CreateTable<PartyEntity>();
            _db.CreateTable<DebtEntity>();
        }
        
        public void SavePatry(IList<Debt> debtsData)
        {
            var partyEntity = new PartyEntity 
            { 
                ID = Guid.NewGuid(),
            };

            var debtEntity = debtsData
                .SelectMany(x => x.Owes
                .Select(o => new DebtEntity
                {
                    PartyID = partyEntity.ID,
                    Name = x.Name,
                    OwesTo = o.Key,// man
                    Amount = o.Value
                }));

            var debtResult = _db.InsertAll(debtEntity);
            var partyResult = _db.Insert(partyEntity);
        }

        public List<PartyEntity> GetAllParties()
        {
            var partyEntities = _db.Table<PartyEntity>()
                .OrderByDescending(x => x.Date)
                .ToList();

            return partyEntities;
        }

        public List<Debt> GetPartyDebtsData(Guid id)
        {
            var debtEntities = _db.Table<DebtEntity>();

            var result = debtEntities
                .Where(x => x.PartyID == id)
                .GroupBy(x => x.Name)
                .Select(x => new Debt
                {
                    Name = x.Key,
                    Owes = x
                    .ToDictionary(group => group.OwesTo, group => group.Amount)
                })
                .ToList();

            return result;
        }
    }
}
