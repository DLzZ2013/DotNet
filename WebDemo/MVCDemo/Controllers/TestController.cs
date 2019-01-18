using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(IndexModel model)
        {
            //数据验证是否通过
            if (ModelState.IsValid)
            {
                var n = ModelState[""];
            }
            //return Content(model.Id + model.name);
            model.Result = model.Num1 + model.Num2;
            return View(model);
        }
    }
}