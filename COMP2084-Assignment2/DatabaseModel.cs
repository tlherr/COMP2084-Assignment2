namespace COMP2084_Assignment2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.opponent_one)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Matches1)
                .WithRequired(e => e.Class1)
                .HasForeignKey(e => e.opponent_two)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Map>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Map>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Map1)
                .HasForeignKey(e => e.map)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .Property(e => e.notes)
                .IsUnicode(false);
        }
    }
}
