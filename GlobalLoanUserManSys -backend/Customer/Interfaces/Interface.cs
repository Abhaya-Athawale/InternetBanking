using Customer.Entity;

namespace Customer.Interfaces
{
    public interface ICustomer
    {
        List<customer> GetAll();
        customer GetbyId(int id);

        void Add(customer customer);
        void Edit(customer customer);

        void Delete(int id);

        int Register(string FirstName,string LastName , string MiddleName , string CustomerCity , string CustomerContactNo , string Occupation , DateTime CustomerDob);

        

    }
}
