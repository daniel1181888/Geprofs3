using System.ComponentModel.DataAnnotations;

namespace Geprofs3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rol {  get; set; }
        public string Afdeling { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static string[] Afdelingen()
        {
            string[] items = { "HR", "ICT", "Marketing" };

            return items;
        }

        public static string[] Rollen()
        {
            string[] items = { "Werkgever", "Werknemer" };

            return items;
        }

        public static string[] Statussen()
        {
            string[] items = { "Afwachting", "Goedgekeurd", "Afgekeurd" };

            return items;
        }
    }
}
