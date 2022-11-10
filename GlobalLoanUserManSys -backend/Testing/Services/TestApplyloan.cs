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
    
    public class TestApplyloan
    {
        DBContext db = new DBContext();
        AccountService a = new AccountService();
        [Fact]
        public async Task Correct()
        {
            var res = a.ApplyLoan(1, "string", 1);
            Account acc = db.accounts.FirstOrDefault(i => i.CustomerId == 1);
            acc.AccntBalance = 100;
            db.accounts.Update(acc);
            db.SaveChanges();
            res.Should().Be(2);
        }
        [Fact]
        public async Task AmountMorethan100000()
        {
            var res = a.ApplyLoan(1, "string", 100000000);
            
            res.Should().Be(3);
        }
        [Fact]
        public async Task AmountLessThanZero()
        {
            var res = a.ApplyLoan(1, "string", -10);

            res.Should().Be(3);
        }
        [Fact]
        public async Task InvalidAccount()
        {
            var res = a.ApplyLoan(1000, "string", 10);

            res.Should().Be(0);
        }
        [Fact]
        public async Task InvalidBranch()
        {
            var res = a.ApplyLoan(1, "invalid-branch", 10);

            res.Should().Be(1);
        }




    }
}
