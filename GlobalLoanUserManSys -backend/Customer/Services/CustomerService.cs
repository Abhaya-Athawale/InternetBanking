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
        public void Add(customer Customer)
        {
            db.customers.Add(Customer);
            db.SaveChanges();

            
        }
        public int Register(string FirstName, string LastName, string MiddleName, string CustomerCity, string CustomerContactNo, string Occupation, DateTime CustomerDob)
        {
            customer cus = new customer();
            cus.FirstName=FirstName;
            cus.LastName=LastName;
            cus.MiddleName=MiddleName;
            cus.CustomerCity=CustomerCity;
            cus.CustomerContactNo=CustomerContactNo;
            cus.CustomerDob=CustomerDob;
            cus.Occupation = Occupation;
            cus.CustomerId = 0;
            db.customers.Add(cus);
            db.SaveChanges();
            return 0;

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
