using Customer.Entity;

namespace Customer.Interfaces
{
    public interface ICustomerLogin
    {
        List<customerLogin> GetAll();
        customerLogin GetbyId(int id);

        customerLogin Add(customerLogin customer);
        bool userLogin(customerLogin customerLogin);
        void Edit(customerLogin customer);

        void Delete(int id);
    }
}
