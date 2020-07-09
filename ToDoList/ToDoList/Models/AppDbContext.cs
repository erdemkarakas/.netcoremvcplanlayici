using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // Eğer database yoksa kendisi oluşturuyor
            this.Database.EnsureCreated();
        }
        public DbSet<Gorev> Gorev { get; set; }
    }
}
