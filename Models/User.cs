namespace SAOnlineMart.Models
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            this.name = name;
            this.email = email;
        }

        public override string ToString()
        {
            return "User ID: " + Id.ToString() + " Name: " + name + " Email: " + email;
        }
    }
}
