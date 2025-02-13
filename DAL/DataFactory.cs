using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {

        public static IRepo<Expense, int, Expense> ExpenseDetails()
        {
            return new ExpenseRepo();
        }
        public static ExpenseFunction ExpenseFunctions()
        {
            return new ExpenseRepo();
        }
        public static IRepo<Budget, int, Budget> BudgetDetails()
        {
            return new BudgetRepo();
        }
        public static IBudgetFunction BudgetFunction()
        {
            return new BudgetRepo();
        }

    }
}
