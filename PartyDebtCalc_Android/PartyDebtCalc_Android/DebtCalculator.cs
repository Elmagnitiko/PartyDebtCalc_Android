using PartyDebtCalc_Android.Models;
using PartyDebtCalc_Android.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PartyDebtCalc_Android
{
    public static class DebtCalculator
    {
        public static List<Debt> CalculateDebts(IList<MemberViewModel> members)
        {
            decimal totalSpent = members.Sum(m => m.Spent);
            decimal eachShouldSpend = Math.Round(totalSpent / members.Count, 2);

            var debts = new List<Debt>();
            var listOfAllMembers = members
                .Select(member => new Member
                {
                    Name = member.Name,
                    Spent = member.Spent,
                })
                .ToArray();

            var listOfDebtors = listOfAllMembers.Where(m => m.Spent < eachShouldSpend).ToArray();
            var listOfCreditors = listOfAllMembers.Where(m => m.Spent > eachShouldSpend).ToArray();

            for (var i = 0; i < listOfDebtors.Length; i++)
            {
                var moneyThisDebtorHaveToReturn = eachShouldSpend - listOfDebtors[i].Spent;

                var debt = new Debt
                {
                    Name = listOfDebtors[i].Name,
                    Owes = new Dictionary<string, decimal>()
                };

                for (int j = 0; j < listOfCreditors.Length; j++)
                {
                    if (moneyThisDebtorHaveToReturn > 0 &&
                        listOfCreditors[j].Spent > eachShouldSpend)
                    {
                        var transaction = CanReturnMoreThisCreditorNeeds(moneyThisDebtorHaveToReturn, listOfCreditors[j].Spent - eachShouldSpend) ?
                            listOfCreditors[j].Spent - eachShouldSpend : moneyThisDebtorHaveToReturn;

                        debt.Owes[listOfCreditors[j].Name] = transaction;

                        moneyThisDebtorHaveToReturn -= transaction;
                        listOfCreditors[j].Spent -= transaction;
                    }
                }
                debts.Add(debt);
            }
            return debts;
        }

        private static bool CanReturnMoreThisCreditorNeeds(decimal moneyThisDebtorHaveToReturn, decimal moneyThisCreditorHaveToRecieve)
        {
            return moneyThisDebtorHaveToReturn > moneyThisCreditorHaveToRecieve;
        }
    }
}
