using Customer.Database;
using Customer.Entity;
using Customer.Interfaces;

namespace Customer.Services
{
    public class TransactionService: InterfaceTransaction
    {

        private readonly DBContext DB;
        public  TransactionService()
        {
            DB =new DBContext();
        }

        public List<Transaction> GetAll()
        {
            return DB.transactions.ToList();
        }

        public Transaction GetbyId(int id)
        {
            return DB.transactions.FirstOrDefault(i => i.TransacId == id); ;
        }

        public void Add(Transaction transaction)
        {
            DB.transactions.Add(transaction);
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            DB.transactions.Remove(DB.transactions.Find(id));
            DB.SaveChanges();
        }


        public void Edit(int id, Transaction transaction)
        {
            Transaction EditedTransac = DB.transactions.Find(id);
            if (EditedTransac != null)
            {
                DB.transactions.Update(EditedTransac).CurrentValues.SetValues(transaction);
                DB.SaveChanges();
            }
        }
    }
}
