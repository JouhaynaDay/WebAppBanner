using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBanner.Models;

namespace WebAppBanner.Context
{
    public class BannerContext:DbContext
    {
        public BannerContext(DbContextOptions<BannerContext> options) : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; }
    }
}
