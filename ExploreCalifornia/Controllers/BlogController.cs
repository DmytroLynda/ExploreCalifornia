using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers {
    public class BlogController : Controller {
        // GET: /<controller>/
        public IActionResult Index() {
            return new ContentResult { Content = "Blog post" };
        }
    }
}
