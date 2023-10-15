using Event_Management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_system.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Presenter> Presenters { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Sector_Presenter> Sector_Presenters { get; set; }
        public DbSet<Sector_Investor>? Sector_Investors { get; set; }
        public DbSet<Event_Management_system.Models.MatchingViewModel>? MatchingViewModel { get; set; }
        public DbSet<SearchViewModel>? SearchViewModels { get; set; }
        public DbSet<Booking>? Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector_Investor>()
                .HasOne(p => p.Sector)
                .WithMany(ba => ba.Sector_Investors)
                .HasForeignKey(bi => bi.Sector_Id);

            modelBuilder.Entity<Sector_Investor>()
                .HasOne(p => p.Investor)
                .WithMany(ba => ba.Sector_Investors)
                .HasForeignKey(bi => bi.Investor_Id);

            modelBuilder.Entity<Sector_Presenter>()
               .HasOne(p => p.Sector)
               .WithMany(ba => ba.Sector_Presenters)
               .HasForeignKey(bi => bi.Sector_Id);

            modelBuilder.Entity<Sector_Presenter>()
                .HasOne(p => p.Presenter)
                .WithMany(ba => ba.Sector_Presenters)
                .HasForeignKey(bi => bi.Presenter_Id);

            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Presenter)
                .WithMany(ba => ba.Bookings)
                .HasForeignKey(bi => bi.Presenter_Id)
                             .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Booking>()
             .HasOne(p => p.Investor)
             .WithMany(ba => ba.Bookings)
             .HasForeignKey(bi =>bi.Investor_Id)
                          .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Booking>()
             .HasOne(p => p.Room)
             .WithMany(ba => ba.Bookings)
             .HasForeignKey(bi => bi.Room_Id)
             .OnDelete(DeleteBehavior.ClientSetNull);
             


        }


    }
}
