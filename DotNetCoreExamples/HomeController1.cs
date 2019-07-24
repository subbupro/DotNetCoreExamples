using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreExamples
{
    public class HomeController1 : Controller
    {
        // GET: /<controller>/
        //Only action is required for the injection , then we need to call like below.
        public IActionResult Index([FromServices] ILog log)
        {
            log.info("Action only required the injections");
            return View();
        }
        // The below is manually get the service instances.
        public IActionResult Index1 ()
        {
            var services = this.HttpContext.RequestServices;
            var log = (ILog)services.GetService(typeof(ILog));

            log.info("Index method executing");

            return View();
        }
    }
}
