using casestudy.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Busycart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly busycartContext _context;
        private object branch;
        private object transactions;
        private object products;
        private object category;
        private object customerid;
        private object custname;

        public ReportController(busycartContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
      [Route("gettransactions")]
       
        
        public ActionResult<List<Report>> GetTransactions()
        {
            var test= this.GetCustomeSecodQuarter(new DateTime(2021, 07, 01), new DateTime(2021, 09, 30));
            return test;
        }
        
        private List<Report> GetCustomeSecodQuarter(DateTime fromDate, DateTime ToDate)
        {
            var query = (from t in _context.Transactions
                         join ci in _context.Customerinfos on t.Custid equals ci.Custid
                         join p in _context.Products on t.Productid equals p.Productid into p_t
                         from p in p_t.DefaultIfEmpty()
                         join c in _context.Categories on p.Categoryid equals c.CatgId into c_t
                         from c in c_t.DefaultIfEmpty()
                         where t.Transdate >= new DateTime(2021, 07, 01) && (t.Transdate) <= new DateTime(2021, 09, 30)
                         group new { ci, c } by new { ci.Custid, ci.Custname, c.CatgName } into g
                         orderby g.Count() descending
                         select new Report
                         {
                             CustId = g.Key.Custid,
                             CustName = g.Key.Custname,
                             TranCount = g.Count(),
                             CatgName = g.Key.CatgName
                         }
                         ).ToList();
            return query;
        }

        //[HttpGet]
        //[Route("gettransactionss")]
        //public ActionResult<List<Report1>> GetTransactionss()
        //{
        //    var test1 = this.CaliforniaQuarterTran(new DateTime(2021, 07, 01), new DateTime(2021, 09, 30));
        //    return test1;
        //}
        //private List<Report1> CaliforniaQuarterTran(DateTime fromDate, DateTime ToDate)
        //{
        //    var query = (from t in _context.Transactions
        //                 join b in _context.Branches on t.Branchid equals b.Branchid
        //                 //where b.Branchname.Contains("California")
        //                 group t by b.branchname into g
        //                 select new Report1
        //                 {
        //                     BranchName = g.Key.ToString(),
        //                     TranCount = g.Count(),
        //                     Volume = g.Sum(x => x.qty ?? 0)
        //                 });
        //                  //.OrderByDescending(x => x.TranCount)
        //                  //.ToList();
                     
        //    return query.ToList();
        //}

        [HttpGet]
        [Route("gettransactionsss")]
        public ActionResult<List<Report3>> GetTransactionsss()
        {
            var test2 = this.ComperativeVolume();
            return test2;
        }
        private List<Report3> ComperativeVolume()
        {
            var query = _context.Payments.Include(x => x.Customer).Where(x => x.Penalty == "YES")
                .Select(x => new Report3 () { 
                    penalty= x.Penalty,
                    Customerid = x.Customerid,
                  CustName = x.Customer.Custname 
            
            }).ToList();
            return query;
        }


        

    }
}
