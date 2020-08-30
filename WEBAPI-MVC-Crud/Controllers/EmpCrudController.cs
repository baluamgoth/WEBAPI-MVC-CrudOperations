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
        public IHttpActionResult getemp()
        {
            cmEntities cm = new cmEntities();
            var results = cm.Newempregs.ToList();
            return Ok(results);
        }
    }
}
