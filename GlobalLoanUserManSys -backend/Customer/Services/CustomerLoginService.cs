using Customer.Database;
using Customer.Entity;
using Customer.Interfaces;

namespace Customer.Services
{
    public class CustomerLoginService : ICustomerLogin
    {
        private readonly DBContext db;
        public CustomerLoginService()
        {
            this.db = new DBContext();
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

        public bool userLogin(customerLogin login)
        {
            if (db.customerLogins.Contains(login)) return true;
            else return false;
        }
    }
}
