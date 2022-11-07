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
        

    }
}
