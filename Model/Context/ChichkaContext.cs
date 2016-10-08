using Model.Models;
using System.Data.Entity;

namespace Model.Context
{
    public class ChichkaContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Account_Game> Account_Games { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().
                HasKey(e => e.Id);
            modelBuilder.Entity<Account_Game>().
                HasKey(e => e.Id);
            modelBuilder.Entity<Game>().
                HasKey(e => e.Id);
            modelBuilder.Entity<User>().
                HasKey(e => e.Id);
            modelBuilder.Entity<Wallet>().
                HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
