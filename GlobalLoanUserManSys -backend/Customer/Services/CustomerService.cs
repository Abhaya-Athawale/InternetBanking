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
        public customer Register(customer Cus)
        {
            if ((!IsDigitsOnly(Cus.CustomerContactNo)) || Cus.CustomerContactNo.Length != 10)
                return null;
            try
            {
                customer cus = new customer();
                cus.FirstName = Cus.FirstName;
                cus.LastName = Cus.LastName;
                cus.MiddleName = Cus.MiddleName;
                cus.CustomerCity = Cus.CustomerCity;
                cus.CustomerContactNo = Cus.CustomerContactNo;
                cus.CustomerDob = Cus.CustomerDob;
                cus.Occupation = Cus.Occupation;
                cus.CustomerId = 0;
                db.customers.Add(cus);
                db.SaveChanges();
                int m=db.customers.Select(p => p.CustomerId).Max();
                customer cus2 = db.customers.FirstOrDefault(i => i.CustomerId == m);
                return cus2;
            }
            catch(Exception ex)
            {
                return null;
            }

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
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
