using App.Enums;

namespace App.Models
{
    public class UsersRoles
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}