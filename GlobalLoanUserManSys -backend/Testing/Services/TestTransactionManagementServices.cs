using Customer.Controllers;
using Customer.Database;
using Customer.Entity;
using Customer.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Testing.Services
{

    public class TestTransactionManagementServices
    {
        TransactionService t = new TransactionService();
        DBContext db = new DBContext();
        [Fact]
        public async Task CorrectWithdraw()
        {
            var res  = t.TransactionManagement(1, "Withdraw", 1);
            var ac = db.accounts.FirstOrDefault(i => i.CustomerId == 1);
            ac.AccntBalance = 100;
            db.accounts.Update(ac);
            db.SaveChanges();
            res.Should().Be(2);
            

        }
        [Fact]
        public async Task CorrectDeposit()
        {
            var res = t.TransactionManagement(1, "Deposit", 1);
            var ac = db.accounts.FirstOrDefault(i => i.CustomerId == 1);
            ac.AccntBalance = 100;
            db.accounts.Update(ac);
            db.SaveChanges();
            res.Should().Be(2);


        }
        [Fact]
        public async Task IncorrectType()
        {
            var res = t.TransactionManagement(1, "sometype", 1);
            
            res.Should().Be(1);


        }
        [Fact]
        public async Task NoAccountFound()
        {
            var res = t.TransactionManagement(88, "Deposit", 1);

            res.Should().Be(0);


        }
        [Fact]
        public async Task AmountNotSufficentToWithdraw()
        {
            var res = t.TransactionManagement(1, "Withdraw", 100000);

            res.Should().Be(3);


        }


    }
}
