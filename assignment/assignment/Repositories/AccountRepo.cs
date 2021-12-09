using assignment.Data;
using assignment.Models;
using assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    public class AccountRepo
    {
        ApplicationDbContext db;

        public AccountRepo(ApplicationDbContext context)
        {
            db = context;
        }


        public bool CreateAccount(BankAccount b, Client c)
        {
            var account = (from ba in db.BankAccounts
                           where ba.AccountNum == b.AccountNum
                           select ba).FirstOrDefault();
            var client = (from ba in db.Clients
                           where ba.ClientID == c.ClientID
                           select ba).FirstOrDefault();

            ClientAccount ca = new ClientAccount()
            {
                AccountNum = account.AccountNum,
                ClientID = client.ClientID
            };
            db.ClientAccounts.Add(ca);
            db.SaveChanges();

            return true;
        }

        public AccountVM GetDetails(int accountNumber)
        {
            var accountNum = (from ca in db.ClientAccounts
                              where ca.AccountNum == accountNumber
                              select new AccountVM()
                              {
                                  ClientID = ca.ClientID,
                                  FirstName = ca.Client.FirstName,
                                  LastName = ca.Client.LastName,
                                  Email = ca.Client.Email,
                                  AccountNum = ca.AccountNum,
                                  AccountType = ca.BankAccount.AccountType,
                                  Balance = ca.BankAccount.Balance
                              }).FirstOrDefault();
            return accountNum;

        }

        public IQueryable<AccountVM> GetAll(string email)
        {
            var client =
                (from c in db.Clients
                 where c.Email == email
                 select c).FirstOrDefault();

            var query =
                from b in db.ClientAccounts
                where b.ClientID == client.ClientID
                orderby b.AccountNum descending
                select new AccountVM()
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    AccountNum = b.AccountNum,
                    AccountType = b.BankAccount.AccountType,
                    Balance = b.BankAccount.Balance
                };

            return query;
        }

        public AccountVM editDetails(int accountNumber, string email)
        {
            var client =
                (from c in db.Clients
                 where c.Email == email
                 select c).FirstOrDefault();

            var query =
                (from b in db.ClientAccounts
                where b.ClientID == client.ClientID
                &&
                b.AccountNum == accountNumber
                orderby b.AccountNum descending
                select new AccountVM()
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    AccountNum = b.AccountNum,
                    AccountType = b.BankAccount.AccountType,
                    Balance = b.BankAccount.Balance
                }).FirstOrDefault();

            return query;
        }
    }
}
