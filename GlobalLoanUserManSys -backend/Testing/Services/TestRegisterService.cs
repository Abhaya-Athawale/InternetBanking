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
    public class TestRegisterService
    {
        DBContext db = new DBContext();
        [Fact]
        public async Task Correct()
        {
            CustomerService c = new CustomerService();
            //string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob
            var res = c.Register("das", "mas", "has", "aluva", "9188037893", "Lender", DateTime.Parse("2022-11-10T04:59:08.758Z"));
            customer delCus = db.customers.FirstOrDefault(i => i.Occupation == "Lender");
            db.customers.Remove(delCus);
            db.SaveChanges();
            res.Should().Be(0);
            


        }
        [Fact]
        public async Task PhoneNoLengthIncorrect()
        {
            CustomerService c = new CustomerService();
            //string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob
            var res = c.Register("das", "mas", "has", "aluva", "918803777893", "Lender", DateTime.Parse("2022-11-10T04:59:08.758Z"));
            
            res.Should().Be(1);



        }
        [Fact]
        public async Task PhoneNoHasNonDigits()
        {
            CustomerService c = new CustomerService();
            //string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob
            var res = c.Register("das", "mas", "has", "aluva", "918803t893", "Lender", DateTime.Parse("2022-11-10T04:59:08.758Z"));
           
            res.Should().Be(1);



        }
    }
}
