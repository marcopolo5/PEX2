using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Rooms.Entity
{
    public partial class RoomsContext : DbContext
    {
        public RoomsContext() : base("name=EntityConnection")
        {
        }
       // public RoomsContext(DbContextOptions<RoomsContext> options) : base(options)
      //  { 
       // }
        public virtual DbSet<admin> Admin { get; set; }
        public virtual DbSet<camera> Camera { get; set; }
        public virtual DbSet<camin> Camin { get; set; }
        public virtual DbSet<formular> Formular { get; set; }
        public virtual DbSet<student> Student { get; set; }
        public virtual DbSet<utilizator> Utilizator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            /*
            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.parola)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .HasMany(e => e.Formular)
                .WithRequired(e => e.camera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<camin>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<camin>()
                .Property(e => e.adresa)
                .IsUnicode(false);

            modelBuilder.Entity<camin>()
                .HasMany(e => e.Camera)
                .WithRequired(e => e.camin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<camin>()
                .HasMany(e => e.Formular)
                .WithRequired(e => e.camin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<student>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.prenume)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.nr_telefon)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.facultate)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .HasMany(e => e.Formular)
                .WithRequired(e => e.student)
                .WillCascadeOnDelete(false);

         /*   modelBuilder.Entity<Rol_Utilizator>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol_Utilizator>()
                .HasMany(e => e.Utilizator)
                .WithRequired(e => e.Rol_Utilizator)
                .WillCascadeOnDelete(false);*/

         /*   modelBuilder.Entity<utilizator>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<utilizator>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<utilizator>()
                .Property(e => e.email)
                .IsUnicode(false);*/
        }
    }

}

