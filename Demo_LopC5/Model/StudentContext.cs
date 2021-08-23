using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Demo_LopC5.Model
{
    public partial class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);
        }
    }
}
