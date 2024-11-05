using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentTeacherManagement.Core.Models;
namespace StudentTeacherManagement.Storage
{
    // Server=KOMPUTER\\SQLEXPRESS;Database=DriversDB;Trusted_Connection=True;TrustServerCertificate=True;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KOMPUTER\\SQLEXPRESS;Database=StudentTeacherDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True")
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
