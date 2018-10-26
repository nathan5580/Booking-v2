namespace Booking_MVVM.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Booking : DbContext
    {
        public Booking()
            : base("name=Booking")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ChambresSet> ChambresSet { get; set; }
        public virtual DbSet<ClientsSet> ClientsSet { get; set; }
        public virtual DbSet<HotelsSet> HotelsSet { get; set; }
        public virtual DbSet<ReservationSet> ReservationSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChambresSet>()
                .HasMany(e => e.ReservationSet)
                .WithOptional(e => e.ChambresSet)
                .HasForeignKey(e => e.Chambres_Id);

            modelBuilder.Entity<ClientsSet>()
                .HasMany(e => e.ReservationSet)
                .WithOptional(e => e.ClientsSet)
                .HasForeignKey(e => e.Client_Id);

            modelBuilder.Entity<HotelsSet>()
                .HasMany(e => e.ChambresSet)
                .WithOptional(e => e.HotelsSet)
                .HasForeignKey(e => e.Hotel_Id);
        }
    }
}
