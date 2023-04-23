using ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApp
{
    public static class Data
    {
     
        public static List<User> people = new List<User>
        {
            new User("admin@gmail.com", "Admin123!"),
            new User("bob@gmail.com", "55555")
        };
    }

    internal class DbWorker
    {
        DataBaseWorker db;
        public DbWorker(DataBaseWorker context)
        {
            db = context;
        }
    }
}
