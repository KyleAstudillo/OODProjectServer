using System;
using Microsoft.EntityFrameworkCore;
using OODProjectServer.Entities;

namespace OODProjectServer.Entities
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
            : base(options)
        {
        }

        public DbSet<CoffeeItem> CoffeeItems { get; set; }
        public DbSet<UserItem> UserItems { get; set; }


        protected override void OnConfiguring 
            (DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server = tcp:oodproject.database.windows.net, 1433; " +
                                                "Initial Catalog = Coffee; " +
                                                "Persist Security Info = False; " +
                                                "User ID = kyle@admin@oodproject.database.windows.net; " +
                                                "Password = #*2C67zCr2uKe4jv; " +
                                                "MultipleActiveResultSets = False; " +
                                                "Encrypt = True; " +
                                                "TrustServerCertificate = False; " +
                                                "Connection Timeout = 30;");
        }

        override public int SaveChanges()
        {
            base.SaveChanges();
            return 0;
        }
    }
}
