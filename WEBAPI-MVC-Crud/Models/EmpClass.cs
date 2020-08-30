using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_MVC_Crud.Models
{
    public class EmpClass
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Empemail { get; set; }
        public string Emplocation { get; set; }
        public string EmpDesignation { get; set; }
    }
}