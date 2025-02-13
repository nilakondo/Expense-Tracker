using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBudgetFunction
    {
        double TotalCostInAPeriod(DateTime sdate, DateTime edate);
        bool Tracking(DateTime sdate, DateTime edate);
    }
}
