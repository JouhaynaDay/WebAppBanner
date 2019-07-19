using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBanner.Context;
using WebAppBanner.Models;
using WebAppBanner.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppBanner.Controllers
{
    [Route("api/Banner")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly BannerContext _context;
        private readonly IBannerService _bannerService;

        public BannerController(BannerContext context, IBannerService bannerService)
        {
            _bannerService = bannerService;
            _context = context;

            if (_context.Banners.Count() == 0)
            {
                // Create a new BannerItem 
                _bannerService.GenerateDefaultBanner();
            }
        }
        // GET: api/Banner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> GetBannerItems()
        {
            return Ok(await _bannerService.GetBannerList());
        }

        // GET: api/Banner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBannerItem(int id)
        {
            var bannerItem = await _bannerService.GetBannerItem(id);

            if (bannerItem == null)
            {
                return NotFound();
            }

            return bannerItem;
        }

        // GET: api/Banner/5
        [HttpGet("GetBannerHtml/{id}")]
        public string GetBannerHtml(int id)
        {
            string bannerHtml =  _bannerService.GetHtml(id);

            //if (string.IsNullOrEmpty(bannerHtml))
            //{
            //    return NotFound();
            //}

            return bannerHtml;
        }
        // POST: api/Banner
        [HttpPost]
        public async Task<ActionResult<Banner>> PostBannerItem(Banner item)
        {
            if (!item.ValidateHtml())
                return BadRequest();

            item.Created = DateTime.Now;
            item.Modified = DateTime.Now;
            _context.Banners.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBannerItem), new { id = item.Id }, item);
        }

        // PUT: api/Banner/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBannerItem(int id, Banner item)
        {
            if (id != item.Id || !item.ValidateHtml())
            {
                return BadRequest();
            }
            item.Modified = DateTime.Now;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Banner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBannerItem(long id)
        {
            var bannerItem = await _context.Banners.FindAsync(id);

            if (bannerItem == null)
            {
                return NotFound();
            }

            _context.Banners.Remove(bannerItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
