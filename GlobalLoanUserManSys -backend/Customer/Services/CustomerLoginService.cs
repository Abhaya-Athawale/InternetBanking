using Customer.Database;
using Customer.Entity;
using Customer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Customer.Services
{
    public class CustomerLoginService : ICustomerLogin
    {
        private readonly DBContext db;
        private readonly IConfiguration _config;
        public CustomerLoginService(IConfiguration configuration)
        {
            this.db = new DBContext();
            _config = configuration;
        }
        public customerLogin login(int id,string pass)
        {
            customerLogin cus = db.customerLogins.FirstOrDefault(i => i.CustomerId == id);
            if (cus == null)
                return null;
            if (cus.Password == pass)
                return cus;
            return null;

        }
        public string GenerateToken(customerLogin cus)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,cus.CustomerId.ToString())

        };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                               _config["Jwt:Audience"],
                                               Claims, expires: DateTime.Now.AddHours(10),
                                               signingCredentials: Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public customerLogin Add(customerLogin customer)
        {
            if (db.customers.FirstOrDefault(i => i.CustomerId == customer.CustomerId) != null)
            {
                db.customerLogins.Add(customer);
                db.SaveChanges();
                return customer;
            }
            else
            {
                return null;

            }


        }

        public void Delete(int id)
        {
            customerLogin delCus = db.customerLogins.FirstOrDefault(i => i.CustomerId == id);
            db.customerLogins.Remove(delCus);
            db.SaveChanges();

        }

        public void Edit(customerLogin customer)
        {
            db.customerLogins.Update(customer);
            db.SaveChanges();
        }

        public List<customerLogin> GetAll()
        {
            return db.customerLogins.ToList();
        }

        public customerLogin GetbyId(int id)
        {
            customerLogin cus = db.customerLogins.FirstOrDefault(i => i.CustomerId == id);
            return cus;
        }
    }
}
