using Customer.Database;
using Customer.Entity;
using Customer.Interfaces;

namespace Customer.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DBContext db;
        public CustomerService()
        {
            this.db = new DBContext();
        }
        public void Add(customer customer)
        {
            db.customers.Add(customer);
            db.SaveChanges();

            
        }

        public void Delete(int id)
        {
            customer delCus =  db.customers.FirstOrDefault(i => i.CustomerId==id);
            db.customers.Remove(delCus);
            db.SaveChanges();

        }

        public void Edit(customer customer)
        {
            db.customers.Update(customer);
            db.SaveChanges();
        }

        public List<customer> GetAll()
        {
            return db.customers.ToList();
        }

        public customer GetbyId(int id)
        {
            customer cus = db.customers.FirstOrDefault(i => i.CustomerId == id);
            return cus;
        }
    }
}
