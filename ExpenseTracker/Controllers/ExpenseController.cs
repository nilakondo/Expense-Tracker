using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : ApiController
    {
        
        [HttpGet]
        [Route("api/expense/all")]
        public HttpResponseMessage Get()
        {
            var data = ExpenseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/expense/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ExpenseService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/expense/create")]
        public HttpResponseMessage Create(ExpenseDTO s)
        {
            ExpenseService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/expense/delete")]
        public HttpResponseMessage Delete(int id)
        {
            ExpenseService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/expense/update")]
        public HttpResponseMessage Update(ExpenseDTO s)
        {
            ExpenseService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/expense/filterbycategory")]
        public HttpResponseMessage FilterByCategory(string category)
        {
            var data = ExpenseService.FilterByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/expense/filterbydate")]
        public HttpResponseMessage FilterByDate(DateTime sdate, DateTime edate)
        {
            var data = ExpenseService.FilterByDate(sdate,edate);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/expense/exportcsv")]
        public HttpResponseMessage ExportCSV()
        {
            var csv = ExpenseService.ExportCSV();
            var fileBytes = Encoding.UTF8.GetBytes(csv);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileBytes)
            };
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "Expenses.csv"
            };
            return response;
        }

    }
}
