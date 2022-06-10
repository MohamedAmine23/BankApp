using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRBD_Framework;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace prbd_2122_g19.model {
    public class BankContext : DbContextBase {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .LogTo(Console.WriteLine,LogLevel.Information)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bank")
                .UseLazyLoadingProxies(true);//proxy:classe qui va être generer par entityframe et qui va herité de nos entités  et implementer un comportement lazy ->lorsqu'on se place sur une entité ,il va faire une requete sql pour récup les data 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Representative>().HasKey(r => new { r.ClientId, r.InternalAccountIban });

            modelBuilder.Entity<Representative>()
                .HasOne(r => r.Client)
                .WithMany(r => r.Representatives)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Representative>()
                 .HasOne(r => r.InternalAccount)
                 .WithMany(r => r.Representatives)
                 .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Agency>()
                .HasOne(r => r.Manager)
                .WithMany(r => r.Agencies)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Client>()
             .HasOne(r => r.Agency)
             .WithMany(r => r.Clients)
             .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Transfer>()
             .HasOne(r => r.Owner)
             .WithMany(r => r.Transfers)
             .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Transfer>()
             .HasOne(r => r.DebitAccount)
             .WithMany(r => r.TransfersDebited)
             .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Transfer>()
             .HasOne(r => r.CreditAccount)
             .WithMany(r => r.TransfersCredited)
             .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Transfer>()
            .HasOne(r => r.Category)
            .WithMany(r => r.Transfers)
            .OnDelete(DeleteBehavior.ClientCascade);
        }
        //Users
        public DbSet<User> Users { get; set; } 
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Client> Clients { get; set; }
        //Account
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<InternalAccount> InternalAccounts{ get; set; }
        public DbSet<ExternalAccount> ExternalAccounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts{ get; set; }
        public DbSet<SavingsAccount> SavingsAccounts{ get; set; }
        //Transfer
        public DbSet<Transfer> Transfers { get; set; }
        //Agency
        public DbSet<Agency> Agencies { get; set; }
        //Representative 
        public  DbSet<Representative> Representatives { get; set; }
        public DbSet<Category> Categories { get; set; }
        public void SeedData() {
            Database.BeginTransaction();
            var manager1 = new Manager( "Bruno", "Lacroix", "bruno@test.com", "bruno");
            var manager2 = new Manager( "Benoît", "Penelle", "ben@test.com", "ben");
            Managers.AddRange(new[] { manager2,manager1});
            SaveChanges();

            var admin1 = new Admin("Admin", "Istrator", "admin@test.com", "admin");
            Admins.Add(admin1);
            SaveChanges();

            var agence1 = new Agency("Agence1", manager2);
            var agence2 = new Agency("Agence2", manager2);
            var agence3 = new Agency("Agence3", manager1);
            Agencies.AddRange(new[] { agence3, agence2, agence1 });
            SaveChanges();
            var client1 = new Client("Bob", "Marley", "bob@test.com", "bob", agence1);
            var client2 = new Client("Caroline", "de Monaco", "caro@tes.com", "caro", agence1);
            var client3 = new Client("Louise", "TheCross", "louise@test.com", "louise", agence2);
            var client4 = new Client("Jules", "TheCross", "jules@test.com", "jules", agence2);
            Clients.AddRange(new[] { client4, client3, client2, client1 });
            SaveChanges();
            var checkingAccount1 = new CheckingAccount("BE02 9999 1017 8207","AAA", -50);
            var checkingAccount2 = new CheckingAccount("BE14 9996 1669 4306","BBB", -10);
            var checkingAccount3 = new CheckingAccount("BE55 9999 6717 9982","DDD",-100);
            CheckingAccounts.AddRange(new[] { checkingAccount3, checkingAccount2, checkingAccount1 });
            SaveChanges();
            var savingsAccount1 = new SavingsAccount("BE71 9991 5987 4787","CCC");
            SavingsAccounts.Add(savingsAccount1);
            SaveChanges();
            var externalAccount1 = new ExternalAccount("BE23 0081 6870 0358","EEE");
            ExternalAccounts.Add(externalAccount1);
            SaveChanges();
            var accountAccess1 = new Representative(client1,checkingAccount1,Type.Holder);
            var accountAccess2 = new Representative(client1,checkingAccount2,Type.Holder);
            var accountAccess3 = new Representative(client1,savingsAccount1,Type.Proxy);
            var accountAccess4 = new Representative(client2,checkingAccount1,Type.Proxy);
            var accountAccess5 = new Representative(client2,checkingAccount3,Type.Holder);
            var accountAccess6 = new Representative(client2,savingsAccount1,Type.Holder);
            Representatives.AddRange(new[] { accountAccess6, accountAccess5, accountAccess4, accountAccess3, accountAccess2, accountAccess1 });
            SaveChanges();
            var virement1 = new Transfer(checkingAccount1, checkingAccount2, 15,"Tx #014", new DateTime(2022,01,15), null, manager2);
            var virement2 = new Transfer(externalAccount1, savingsAccount1, 5,"Tx #007", new DateTime(2022, 01, 04), new DateTime(2022, 01, 08));
            var virement3 = new Transfer(checkingAccount2, savingsAccount1, 35,"Tx #012", new DateTime(2022, 01, 12), new DateTime(2022, 01, 14), client1);
            var virement4 = new Transfer(savingsAccount1, externalAccount1, 10,"Tx #009", new DateTime(2022, 01, 07), new DateTime(2022, 01, 11), client1);
            var virement5 = new Transfer(checkingAccount2, checkingAccount1, 20,"Tx #006", new DateTime(2022, 01, 03), new DateTime(2022, 01, 07), client1);
            var virement6 = new Transfer(checkingAccount1, checkingAccount2, 50,"Tx #005", new DateTime(2022, 01, 02), new DateTime(2022, 01, 04), client1);
            var virement7 = new Transfer(checkingAccount1, savingsAccount1, 5,"Tx #002", new DateTime(2022, 01, 01), new DateTime(2022, 01, 05), client2);
            var virement8 = new Transfer(checkingAccount1, checkingAccount2, 35,"Tx #003", new DateTime(2022, 01, 01), new DateTime(2022, 01, 09), client2);
            var virement9 = new Transfer(savingsAccount1, checkingAccount2, 100,"Tx #008", new DateTime(2022, 01, 06), null, client2);
            var virement10 = new Transfer(checkingAccount1, savingsAccount1, 15,"Tx #011", new DateTime(2022, 01, 11), new DateTime(2022, 01, 16), client2);
            var virement11 = new Transfer(checkingAccount1, savingsAccount1, 100,"Tx #013", new DateTime(2022, 01, 13), null, client2);
            var virement12 = new Transfer(checkingAccount2, savingsAccount1, 15,"Tx #004", new DateTime(2022, 01, 02), new DateTime(2022, 01, 03), client1);
            var virement13 = new Transfer(savingsAccount1, checkingAccount1, 15,"Tx #010", new DateTime(2022, 01, 10), null, client1);
            var virement14 = new Transfer(checkingAccount1, checkingAccount2, 10,"Tx #001", new DateTime(2022, 01, 01), null, client1);
            Transfers.AddRange(new[] { virement14, virement13,
                virement12, 
                virement11, virement10, virement9, virement8, virement7, virement6, virement5, virement4, virement3, virement2, virement1 });
            SaveChanges();
            var categorie1 = new Category("Category1");
            var categorie2 = new Category("Category2");
            var categorie3 = new Category("Category3");
            var categorie4 = new Category("Category4");
            var categorie5 = new Category("Category5");
            Categories.AddRange(new[] {categorie5,categorie4,categorie3,categorie2,categorie1});
            SaveChanges();
            Database.CommitTransaction();
            Console.WriteLine("seed data :ok");
            
        }

    }
}
