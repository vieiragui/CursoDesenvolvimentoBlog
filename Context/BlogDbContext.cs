using CursoDesenvolvimentoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDesenvolvimentoWeb.Context
{
    public class BlogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}