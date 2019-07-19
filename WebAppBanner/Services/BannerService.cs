using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBanner.Context;
using WebAppBanner.Models;

namespace WebAppBanner.Services
{
    public class BannerService: IBannerService
    {
        private readonly BannerContext _context;

        public BannerService(BannerContext bannerContext)
        {
            _context = bannerContext;
        }

        public void GenerateDefaultBanner()
        {
            _context.Banners.Add(new Banner { Html = "<div> Item1_This is TestCode for BannerFlow</div>" , Created=DateTime.Now,Modified=DateTime.Now});
            _context.Banners.Add(new Banner { Html = "<div> Item2_This is TestCode for BannerFlow</div>", Created = DateTime.Now, Modified = DateTime.Now });
            _context.Banners.Add(new Banner { Html = "<div> Item3_This is TestCode for BannerFlow</div>", Created = DateTime.Now, Modified = DateTime.Now });
            _context.SaveChanges();
        }
        public string GetHtml(int id)
        {
            return _context.Banners.Where(b=>  b.Id==id).FirstOrDefault().Html;
        }

        public async Task <Banner> GetBannerItem(int id)
        {
            return await _context.Banners.FindAsync(id);
        }
        public async Task<IEnumerable<Banner>> GetBannerList()
        {
            return await _context.Banners.ToListAsync();
        }
    }
}
