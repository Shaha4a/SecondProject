using System.Data;

namespace WebApplication5.Entity
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
