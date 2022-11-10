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
            customer cus = new customer();
            cus.FirstName = "das";
            cus.LastName = "mas";
            cus.MiddleName = "has";
            cus.CustomerCity = "aluva";
            cus.CustomerContactNo = "9188037893";
            cus.Occupation = "Lender";
            cus.CustomerDob = DateTime.Parse("2022-11-10T04:59:08.758Z");
            cus.CustomerId = 0;
            var res = c.Register(cus);
        
            customer delCus = db.customers.FirstOrDefault(i => i.Occupation == "Lender");
            db.customers.Remove(delCus);
            db.SaveChanges();
            res.Should().NotBeNull();
            


        }
        [Fact]
        public async Task PhoneNoLengthIncorrect()
        {
            CustomerService c = new CustomerService();
            //string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob
            customer cus = new customer();
            cus.FirstName = "das";
            cus.LastName = "mas";
            cus.MiddleName = "has";
            cus.CustomerCity = "aluva";
            cus.CustomerContactNo = "918803777893";
            cus.Occupation = "Lender";
            cus.CustomerDob = DateTime.Parse("2022-11-10T04:59:08.758Z");
            cus.CustomerId = 0;
            var res = c.Register(cus);

            res.Should().BeNull();



        }
        [Fact]
        public async Task PhoneNoHasNonDigits()
        {
            CustomerService c = new CustomerService();
            //string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob
            customer cus = new customer();
            cus.FirstName = "das";
            cus.LastName = "mas";
            cus.MiddleName = "has";
            cus.CustomerCity = "aluva";
            cus.CustomerContactNo = "918803t893";
            cus.Occupation = "Lender";
            cus.CustomerDob = DateTime.Parse("2022-11-10T04:59:08.758Z");
            cus.CustomerId = 0;
            var res = c.Register(cus);

            res.Should().BeNull();



        }
    }
}
