using Geprofs3.Data;
using Geprofs3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Geprofs3.Controllers
{
    [Authorize]
    public class AanvraagController : Controller
    {
        private readonly Geprofs3Context _context;
        private List<User> Users = new List<User>();
        string[] _statussen = Models.User.Statussen();
        string[] _rollen = Models.User.Rollen();
        string[] _afdelignen = Models.User.Afdelingen();

        public AanvraagController(Geprofs3Context context)
        {
            _context = context;
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();

            user1.Id = 1;
            user1.Rol = _rollen[1];
            user1.Afdeling = _afdelignen[0];
            user1.FirstName = "Jan";
            user1.LastName = "Janssen";
            user1.Email = "jan.janssen@geoprofs.com";
            user1.Password = "Password123";

            user2.Id = 2;
            user2.Rol = _rollen[1];
            user2.Afdeling = _afdelignen[1];
            user2.FirstName = "Daniël";
            user2.LastName = "Kuhlmann";
            user2.Email = "daniel.kuhlmann@geoprofs.com";
            user2.Password = "DanielIsDBeste";

            user3.Id = 3;
            user3.Rol = _rollen[1];
            user3.Afdeling = _afdelignen[2];
            user3.FirstName = "Jennifer";
            user3.LastName = "Lopez";
            user3.Email = "jennifer.lopez@geoprofs.com";
            user3.Password = "ICanSing";

            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: VerlofAanvraags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Naam,Rol,Afdeling,BeginDatum,EindDatum,Reden,Status")] VerlofAanvraag verlofAanvraag)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                User user = Users[rnd.Next(0, Users.Count)];

                verlofAanvraag.Naam = user.FirstName;
                verlofAanvraag.Rol = user.Rol;
                verlofAanvraag.Afdeling = user.Afdeling;
                verlofAanvraag.Status = _statussen[0];

                _context.Add(verlofAanvraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verlofAanvraag);
        }
    }
}
