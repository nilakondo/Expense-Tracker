using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ExpenseFunction
    {
        List<Expense> FilterByCategory(string category);
        List<Expense> FilterByDate(DateTime sdate, DateTime edate);
    }
}
