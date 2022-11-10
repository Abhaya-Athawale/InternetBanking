using Customer.Controllers;
using Customer.Database;
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
    public class TestLoginService
    {
        private readonly DBContext db;
        private readonly IConfiguration _config;
        [Fact]
        public async Task CorrectLogin()
        {
            CustomerLoginService c = new CustomerLoginService(_config);

           var token =  c.login(1, "asd");
           
            token.Should().NotBeNull();
            

        }
        [Fact]
        public async Task IncorrectPassword()
        {
            CustomerLoginService c = new CustomerLoginService(_config);

            var token = c.login(1, "asdx");
           
            token.Should().BeNull();


        }
        [Fact]
        public async Task IncorrectUsername()
        {
            CustomerLoginService c = new CustomerLoginService(_config);

            var token = c.login(78, "asd");

            token.Should().BeNull();


        }
    }
}
