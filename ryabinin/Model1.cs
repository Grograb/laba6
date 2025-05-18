using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ryabinin
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Priсelist> Priсelist { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priсelist>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Priсelist>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Priсelist>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);
        }
    }
}
