using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{

    internal class BudgetRepo : Repo, IRepo<Budget, int, Budget>, IBudgetFunction
    {
            public Budget Create(Budget obj)
            {
                db.Budgets.Add(obj);
                db.SaveChanges();
                return obj;
            }

            public bool Delete(int id)
            {
                var ex = Get(id);
                db.Budgets.Remove(ex);
                return db.SaveChanges() > 0;
            }

            public Budget Get(int id)
            {
                return db.Budgets.Find(id);
            }

            public List<Budget> Get()
            {
                return db.Budgets.ToList();
            }

        public double TotalCostInAPeriod(DateTime sdate, DateTime edate)
        {
            return (from expense in db.Expenses
                            where expense.Date >= sdate && expense.Date <= edate
                            select expense.Amount).Sum();
        }

        public bool Tracking(DateTime sdate, DateTime edate)
        {
            var cost=TotalCostInAPeriod(sdate, edate);
            var maxcost = (from budget in db.Budgets
                           where budget.StartDate==sdate && budget.EndDate==edate
                           select budget.Amount).SingleOrDefault();
            return maxcost>cost;
        }

        public Budget Update(Budget obj)
            {
                var ex = Get(obj.Id);
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return ex;
            }
        }
    
}
