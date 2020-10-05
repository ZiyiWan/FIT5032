namespace FIT5032_Week07.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<StudentsSet> StudentsSet { get; set; }
        public virtual DbSet<UnitsSet> UnitsSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsSet>()
                .HasMany(e => e.UnitsSet)
                .WithRequired(e => e.StudentsSet)
                .HasForeignKey(e => e.StudentsId)
                .WillCascadeOnDelete(false);
        }
    }
}
