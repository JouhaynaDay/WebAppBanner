using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBanner.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public bool ValidateHtml()
        {
           
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(this.Html);

            if (doc.ParseErrors.Count() > 0)
            {
                //Invalid HTML
                return false;
            }
            return true;
        }
    }
}
