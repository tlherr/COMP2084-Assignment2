namespace COMP2084_Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Opponent> Opponents { get; set; }
        public virtual DbSet<Spec> Specs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Class>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Opponents)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.class_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Specs)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.class_id);

            modelBuilder.Entity<Match>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<Match>()
                .Property(e => e.map)
                .IsFixedLength();

            modelBuilder.Entity<Opponent>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Opponent>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Opponent)
                .HasForeignKey(e => e.opponent_1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Opponent>()
                .HasMany(e => e.Matches1)
                .WithRequired(e => e.Opponent1)
                .HasForeignKey(e => e.opponent_2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spec>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Spec>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<Spec>()
                .HasMany(e => e.Opponents)
                .WithRequired(e => e.Spec)
                .HasForeignKey(e => e.spec_id)
                .WillCascadeOnDelete(false);
        }
    }
}
