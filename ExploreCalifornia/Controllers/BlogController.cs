using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers {
    [Route("blog")]
    public class BlogController : Controller {
        [Route("")]
        public IActionResult Index() {
            return View();
        }

        [Route("blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key) {
            return View();
        }
    }
}
