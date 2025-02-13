using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BudgetService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Budget, BudgetDTO>();
                cfg.CreateMap<BudgetDTO, Budget>();
            });
            return new Mapper(config);
        }

        public static List<BudgetDTO> Get()
        {
            var repo = DataFactory.BudgetDetails();
            return GetMapper().Map<List<BudgetDTO>>(repo.Get());
        }
        public static BudgetDTO Get(int id)
        {
            var repo = DataFactory.BudgetDetails();
            return GetMapper().Map<BudgetDTO>(repo.Get(id));
        }

        public static bool Create(BudgetDTO obj)
        {
            return DataFactory.BudgetDetails().Create(GetMapper().Map<Budget>(obj)) != null;
        }
        public static bool Delete(int id)
        {
            return DataFactory.BudgetDetails().Delete(id);
        }
        public static bool Update(BudgetDTO obj)
        {
            return DataFactory.BudgetDetails().Update(GetMapper().Map<Budget>(obj)) != null;
        }
        public static bool Tracking(DateTime sdate, DateTime edate)
        {
            return DataFactory.BudgetFunction().Tracking(sdate, edate);
        }



    }
}
