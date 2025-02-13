using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace budgetTracker.Controllers
{
    public class BudgetController : ApiController
    {
        [HttpGet]
        [Route("api/budget/all")]
        public HttpResponseMessage Get()
        {
            var data = BudgetService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/budget/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = BudgetService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/budget/create")]
        public HttpResponseMessage Create(BudgetDTO s)
        {
            BudgetService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/budget/delete")]
        public HttpResponseMessage Delete(int id)
        {
            BudgetService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/budget/update")]
        public HttpResponseMessage Update(BudgetDTO s)
        {
            BudgetService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/budget/tracking")]
        public HttpResponseMessage Tracking(DateTime sdate, DateTime edate)
        {
            var data = BudgetService.Tracking(sdate,edate);
            string sms = "";
            if (data)
            {
                sms = "Budget is under control";
            }
            else
            {
                sms = "budget exceeded";
            }
            return Request.CreateResponse(HttpStatusCode.OK,sms);
        }

    }
}
