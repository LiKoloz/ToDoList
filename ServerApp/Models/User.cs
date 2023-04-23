namespace ServerApp.Models
{
    public class User
    {
        public User() { }
        public User(string email, string password) {
            Email = email;
            UserPassword = password;
        }

        public int Id { get; set; }
    public string Email { get; set; }

    public string UserPassword { get; set; }

        public List<string> CompletedTasks = new List<string> { };
        public List<string> ProgressTasks = new List<string> { };
    };
}
