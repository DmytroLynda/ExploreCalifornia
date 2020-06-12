using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Model {
    public class BlogDataContext : DbContext {
        public DbSet<Post> Posts { get; set; }
    }
}
