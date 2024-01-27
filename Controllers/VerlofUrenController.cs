using Geprofs3.Data;
using Geprofs3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Geprofs3.Controllers
{
    [Authorize]
    public class VerlofUrenController : Controller
    {
        private readonly Geprofs3Context _context;

        public VerlofUrenController(Geprofs3Context context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            var aanvragen = from a in _context.VerlofAanvraag select a;
            aanvragen = aanvragen.Where(s => s.Status!.Contains("Goedgekeurd"));

            return View(await aanvragen.ToListAsync());
        }
    }
}
