using jalvadev_back.Utils;

namespace jalvadev_back.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string About { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
