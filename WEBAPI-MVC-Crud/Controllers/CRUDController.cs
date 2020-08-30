using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPI_MVC_Crud.Models;
using System.Net.Http;

namespace WEBAPI_MVC_Crud.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            IEnumerable<Newempreg> empObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress=new Uri("http://localhost:53465/api/EmpCrud");

            var consumeapi = hc.GetAsync("EmpCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<Newempreg>>();
                displaydata.Wait();

                empObj = displaydata.Result;
            }
            return View(empObj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Newempreg insertemp)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53465/api/EmpCrud");

            var insertrecord = hc.PostAsJsonAsync("EmpCrud",insertemp);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            EmpClass empObj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53465/api/");

            var consumeapi = hc.GetAsync("EmpCrud?id="+id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empObj = displaydata.Result;
            }
            return View(empObj);

        }

        public ActionResult Edit(int id)
        {
            EmpClass empObj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53465/api/");

            var consumeapi = hc.GetAsync("EmpCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empObj = displaydata.Result;
            }
            return View(empObj);
        }

        [HttpPost]
        public ActionResult Edit(EmpClass ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53465/api/EmpCrud");
            var insertrecord = hc.PutAsJsonAsync<EmpClass>("EmpCrud", ec);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Employee Record not updated";
            }
            return View(ec);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53465/api/EmpCrud");

            var delrecord = hc.DeleteAsync("EmpCrud/" + id.ToString());
            delrecord.Wait();

            var displaydatadel = delrecord.Result;
            if (displaydatadel.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}