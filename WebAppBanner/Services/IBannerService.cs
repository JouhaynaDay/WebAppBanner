using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBanner.Models;

namespace WebAppBanner.Services
{
   public interface IBannerService
    {
        void GenerateDefaultBanner();
         Task<IEnumerable<Banner>> GetBannerList();
        Task<Banner> GetBannerItem(int id);
        string GetHtml(int id);

    }
}
