using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace entity1.Models
{
    public class YourContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Server = "localhost";
            string Port = "8889"; 
            string Database = "ef_db";
            string UserId = "root";
            string Password = "root";
            string Connection = $"Server={Server};port={Port};database={Database};uid={UserId};pwd={Password};SslMode=None;";
            optionsBuilder.UseMySQL(Connection);
        }
         public DbSet<User> Users { get; set; }
    }
}