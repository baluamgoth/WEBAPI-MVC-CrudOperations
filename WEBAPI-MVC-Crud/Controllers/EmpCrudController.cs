using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_MVC_Crud.Models;

namespace WEBAPI_MVC_Crud.Controllers
{
    public class EmpCrudController : ApiController
    {
        cmEntities cm = new cmEntities();
        public IHttpActionResult getemp()
        {  
            var results = cm.Newempregs.ToList();
            return Ok(results);
        }
        [HttpPost]
        public IHttpActionResult empinsert(Newempreg empinsert)
        {
            cm.Newempregs.Add(empinsert);
            cm.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetEmpid(int id)
        {
            EmpClass empdetails = null;
            empdetails = cm.Newempregs.Where(x => x.Empid == id).Select(x => new EmpClass
            {
                Empid = x.Empid,
                Empname = x.Empname,
                Empemail = x.Empemail,
                Emplocation = x.Emplocation,
                EmpDesignation = x.EmpDesignation,
            }).FirstOrDefault<EmpClass>();

            if (empdetails == null)
            {
                return NotFound();
            }
            return Ok(empdetails);
        }

        public IHttpActionResult Put(EmpClass ec)
        {
            var updateemp = cm.Newempregs.Where(x => x.Empid == ec.Empid).FirstOrDefault<Newempreg>();
            if (updateemp != null)
            {
                updateemp.Empid = ec.Empid;
                updateemp.Empname = ec.Empname;
                updateemp.Empemail = ec.Empemail;
                updateemp.Emplocation = ec.Emplocation;
                updateemp.EmpDesignation = ec.EmpDesignation;

                cm.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
