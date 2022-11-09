using Customer.Entity;

namespace Customer.Interfaces
{
    public interface InterfaceTransaction
    {
        List<Transaction> GetAll();
        Transaction GetbyId(int id);

        void Add(Transaction transaction);
        void Edit(int id,Transaction transaction);

        void Delete(int id);

    }
}
