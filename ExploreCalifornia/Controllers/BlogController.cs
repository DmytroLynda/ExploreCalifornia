using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route(@"{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key) 
        {
            var post = new Post
            {
                Title = "My blog post",
                Author = "Dmytro Lynda",
                Body = "This is a great blog post, don't you think?",
                Posted = DateTime.Now
            };

            return View(post);
        }
    }
}