using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreExamples
{
    public class HomeController : Controller
    {
        // The below is the constructor injections.
        ILog _log;
        // GET: /<controller>/
        public IActionResult Index()
        {
            _log.info("Executing /home/index");

            return View("Index");
        }
        public HomeController(ILog log)
        {
            _log = log;
            
        }

    }
}
