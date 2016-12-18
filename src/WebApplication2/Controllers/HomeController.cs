using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/ee")]
        public string aa() => "zhi";
        
        public string aaa() => "zhii";
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(new cc() { nameid=1,name="eee"});
        }
    }
    public class cc
    {
        public int nameid { get; set; }
        public  string  name { get; set; }
    }
}
