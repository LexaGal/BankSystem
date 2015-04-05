using MvcMovie.Models;

namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.ClientsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovie.Models.ClientsDbContext context)
        {
              Random rnd = new Random();
              context.Clients.AddOrUpdate(i => i.SecondName,
                  new Client
                  {
                      FirstName = "Are",
                      SecondName = "Jiop",
                      Email = "Rom@nn.ind",
                      Password = "niumy8o",
                      AccountType = "Usual",
                      State = new AccountState()
                      {
                          PinCode = rnd.Next(1000, 9999).ToString(),
                          CardID = Guid.NewGuid().ToString().Substring(0, 8),
                          BankMoney = rnd.Next(1000000, 100000000),
                          BankProcents = rnd.Next(1, 25)
                          
                      }
                  },

                 new Client
                 {
                     FirstName = "Bo",
                     SecondName = "Kiuy",
                     Email = "Comedy@hgh.com",
                     Password = "jkyi8ybn",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

                 new Client
                 {
                     FirstName = "Gaq",
                     SecondName = "Njhj",
                     Email = "Comedy@n.ru",
                     Password = "878nui",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

               new Client
               {
                   FirstName = "Ale",
                   SecondName = "Brano",
                   Email = "Western@m.ru",
                   Password = "000000",
                   AccountType = "Usual",
                   State = new AccountState()
                   {
                       PinCode = rnd.Next(1000, 9999).ToString(),
                       CardID = Guid.NewGuid().ToString().Substring(0, 8),
                       BankMoney = rnd.Next(1000000, 100000000),
                       BankProcents = rnd.Next(1, 25)

                   }
               },
                  new Client
                  {
                      FirstName = "Aop",
                      SecondName = "Jiopou",
                      Email = "Rom@nn.ind",
                      Password = "niumyklk8o",
                      AccountType = "Usual",
                      State = new AccountState()
                      {
                          PinCode = rnd.Next(1000, 9999).ToString(),
                          CardID = Guid.NewGuid().ToString().Substring(0, 8),
                          BankMoney = rnd.Next(1000000, 100000000),
                          BankProcents = rnd.Next(1, 25)

                      }
                  },

                 new Client
                 {
                     FirstName = "Bil",
                     SecondName = "Kilklkuy",
                     Email = "Comedy@hgh.com",
                     Password = "jkyi8ybn",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

                 new Client
                 {
                     FirstName = "Goi",
                     SecondName = "Njoohjo",
                     Email = "Comedylklk@n.ru",
                     Password = "878nui",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

               new Client
               {
                   FirstName = "Riok",
                   SecondName = "Brapip",
                   Email = "Western@m00.ru",
                   Password = "000000",
                   AccountType = "Usual",
                   State = new AccountState()
                   {
                       PinCode = rnd.Next(1000, 9999).ToString(),
                       CardID = Guid.NewGuid().ToString().Substring(0, 8),
                       BankMoney = rnd.Next(1000000, 100000000),
                       BankProcents = rnd.Next(1, 25)

                   }
               },
                  new Client
                  {
                      FirstName = "Alklk",
                      SecondName = "Jiopoiupo",
                      Email = "Rom@nn.ind",
                      Password = "niumy8o",
                      AccountType = "Usual",
                      State = new AccountState()
                      {
                          PinCode = rnd.Next(1000, 9999).ToString(),
                          CardID = Guid.NewGuid().ToString().Substring(0, 8),
                          BankMoney = rnd.Next(1000000, 100000000),
                          BankProcents = rnd.Next(1, 25)

                      }
                  },

                 new Client
                 {
                     FirstName = "Bob",
                     SecondName = "Kiumyio",
                     Email = "Comedy@hgh.com",
                     Password = "jkyi8ybn",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

                 new Client
                 {
                     FirstName = "Ger",
                     SecondName = "Nujhjoii",
                     Email = "Comedy@n.ru",
                     Password = "878nui",
                     AccountType = "Usual",
                     State = new AccountState()
                     {
                         PinCode = rnd.Next(1000, 9999).ToString(),
                         CardID = Guid.NewGuid().ToString().Substring(0, 8),
                         BankMoney = rnd.Next(1000000, 100000000),
                         BankProcents = rnd.Next(1, 25)

                     }
                 },

               new Client
               {
                   FirstName = "Rio",
                   SecondName = "Brayk",
                   Email = "Western@m.ru",
                   Password = "000000",
                   AccountType = "Usual",
                   State = new AccountState()
                   {
                       PinCode = rnd.Next(1000, 9999).ToString(),
                       CardID = Guid.NewGuid().ToString().Substring(0, 8),
                       BankMoney = rnd.Next(1000000, 100000000),
                       BankProcents = rnd.Next(1, 25)

                   }
               },
                new Client
                {
                    FirstName = "Aki",
                    SecondName = "Jiopiunk",
                    Email = "Rom@nn.ind",
                    Password = "niumy8o",
                    AccountType = "Usual",
                    State = new AccountState()
                    {
                        PinCode = rnd.Next(1000, 9999).ToString(),
                        CardID = Guid.NewGuid().ToString().Substring(0, 8),
                        BankMoney = rnd.Next(1000000, 100000000),
                        BankProcents = rnd.Next(1, 25)

                    }
                }
           );
            
        }
    }
}