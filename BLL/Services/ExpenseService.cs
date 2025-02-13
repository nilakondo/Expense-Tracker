using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExpenseService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Expense, ExpenseDTO>();
                cfg.CreateMap<ExpenseDTO, Expense>();
            });
            return new Mapper(config);
        }

        public static List<ExpenseDTO> Get()
        {
            var repo = DataFactory.ExpenseDetails();
            return GetMapper().Map<List<ExpenseDTO>>(repo.Get());
        }
        public static ExpenseDTO Get(int id)
        {
            var repo = DataFactory.ExpenseDetails();
            return GetMapper().Map<ExpenseDTO>(repo.Get(id));
        }

        public static bool Create(ExpenseDTO obj)
        {
            return DataFactory.ExpenseDetails().Create(GetMapper().Map<Expense>(obj))!=null;
        }
        public static bool Delete(int id)
        {
            return DataFactory.ExpenseDetails().Delete(id);
        }
        public static bool Update(ExpenseDTO obj)
        {
            return DataFactory.ExpenseDetails().Update(GetMapper().Map<Expense>(obj))!= null;
        }

        public static List<ExpenseDTO> FilterByCategory(string category)
        {
            return GetMapper().Map<List<ExpenseDTO>>(DataFactory.ExpenseFunctions().FilterByCategory(category));
        }

        public static List<ExpenseDTO> FilterByDate(DateTime sdate, DateTime edate)
        {
            return GetMapper().Map<List<ExpenseDTO>>(DataFactory.ExpenseFunctions().FilterByDate(sdate,edate));
        }
        public static string ExportCSV()
        {
            var expenses = GetMapper().Map<List<ExpenseDTO>>(DataFactory.ExpenseDetails().Get());
            var csv = new StringBuilder();
            csv.AppendLine("Id,Category,Date,Description,Ammount");
            foreach (var expense in expenses)
            {
                csv.AppendLine($"{expense.Id},{expense.Category},{expense.Date},{expense.Description},{expense.Amount}");
            }
            return csv.ToString();
        }
    }
}
