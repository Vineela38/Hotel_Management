using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel_Management.Models;
using Hotel_Management.Models.ENTITY;

namespace Hotel_Management.Data
{
    public class HotelDb:DbContext
    {
        public HotelDb(DbContextOptions<HotelDb> options):base(options){}
        public DbSet<SignUp> signUps{set;get;}
        public DbSet<Login> logins{set;get;}

        public DbSet<ForgotPassword> forgots{set;get;}
        //public DbSet<Registration>registrations{set;get;}
        public DbSet<Hotel> hotels{set;get;}
        public DbSet<PaymentDetails>paymentDetails{set;get;}

        public DbSet<HotelBooking> hotelBookings{set;get;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().Property(x=>x.HotelId).ValueGeneratedNever();
            modelBuilder.Entity<PaymentDetails>().Property(x=>x.BookingId).ValueGeneratedNever();
            modelBuilder.Entity<SignUp>().Property(x=>x.Email).ValueGeneratedNever();
            modelBuilder.Entity<Login>().Property(x=>x.Email).ValueGeneratedNever();
            modelBuilder.Entity<ForgotPassword>().Property(x=>x.Email).ValueGeneratedNever();
        }
    }
}