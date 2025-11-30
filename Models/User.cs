namespace RPKApp2.Models
{
    public class User
    {
        public string Id { get; }
        public string Email { get; }
        public string? Phone { get; }

        public User(string id, string email, string? phone = null)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }
    }
}