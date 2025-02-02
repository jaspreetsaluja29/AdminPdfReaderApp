using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AdminPdfReaderApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<AdminUser> AdminUsers { get; set; }
    }

    public class AdminUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
