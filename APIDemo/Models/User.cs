namespace APIDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public DateTime? birthDate { get; }

        public Account? Account { get; set; }
        public Credit? Credit { get; set; }

        public User(string name, string email, DateTime birthDate) { 
            this.Id= 1;
            this.Name = name;
            this.Email = email;
            this.birthDate = birthDate;
        }
    }
}
