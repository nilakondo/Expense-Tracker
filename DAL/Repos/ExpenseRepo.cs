using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace DAL.Repos
{
    internal class ExpenseRepo : Repo, IRepo<Expense, int, Expense>, ExpenseFunction
    {
        public Expense Create(Expense obj)
        {
            db.Expenses.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Expenses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Expense> FilterByCategory(string category)
        {
            return (from expense in db.Expenses
                    where expense.Category == category
                    select expense).ToList();
        }

        public List<Expense> FilterByDate(DateTime sdate, DateTime edate)
        {
            return (from expense in db.Expenses
                    where expense.Date >= sdate && expense.Date <= edate
                    select expense).ToList();
        }

        public Expense Get(int id)
        {
            return db.Expenses.Find(id);
        }

        public List<Expense> Get()
        {
            return db.Expenses.ToList();
        }



        public Expense Update(Expense obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }

    }
}
