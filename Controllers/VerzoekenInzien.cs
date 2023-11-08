using Geprofs3.Data;
using Geprofs3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Geprofs3.Controllers
{
    public class VerzoekenInzien : Controller
    {
        private readonly Geprofs3Context _context;
        private List<User> Users = new List<User>();
        string[] _statussen = Models.User.Statussen();
        string[] _rollen = Models.User.Rollen();
        string[] _afdelignen = Models.User.Afdelingen();

        public VerzoekenInzien(Geprofs3Context context)
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

        public async Task<IActionResult> Index(string columns, string searchString, string verzoekId, string verzoekKeuring)
        {
            if (!String.IsNullOrEmpty(verzoekId) && !String.IsNullOrEmpty(verzoekKeuring))
            {
                VerlofAanvraag verzoek = _context.VerlofAanvraag.FirstOrDefault(a => a.Id == Convert.ToInt32(verzoekId));
                verzoek.Status = verzoekKeuring;
                _context.Update(verzoek);
                _context.SaveChanges();

            }

            var aanvragen = from a in _context.VerlofAanvraag
                            where a.Status.ToLower() == "afwachting"
                            select a;

            if (!String.IsNullOrEmpty(columns) && !String.IsNullOrEmpty(searchString))
            {
                switch (columns)
                {
                    case "naam":
                        aanvragen = aanvragen.Where(s => s.Naam!.Contains(searchString));
                        break;

                    case "rol":
                        aanvragen = aanvragen.Where(s => s.Rol!.Contains(searchString));
                        break;

                    case "afdeling":
                        aanvragen = aanvragen.Where(s => s.Afdeling!.Contains(searchString));
                        break;

                    case "status":
                        aanvragen = aanvragen.Where(s => s.Status!.Contains(searchString));
                        break;

                    default:
                        break;
                }
            }

            return View(await aanvragen.ToListAsync());
        }
    }
}
