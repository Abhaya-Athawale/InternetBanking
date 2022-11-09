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
        public int TransactionManagement(int CusId, string type, int amount)
        {
            Account acc = DB.accounts.FirstOrDefault(i => i.CustomerId == CusId);
            if (acc == null)
                return 0;
            if (type != "Withdraw" && type != "Deposit")
                return 1;

                Transaction t = new Transaction();
            t.AccntId = acc.AccntId;
            t.CustomerId = CusId;
            t.TransacDate = DateTime.Now;
            t.TransacType = type;
            t.TransacAmnt = amount;
            if (type == "Withdraw")
            {
                acc.AccntBalance = acc.AccntBalance - amount;
                if (acc.AccntBalance < 0)
                    return 3;
            }
            else if (type == "Deposit")
                acc.AccntBalance = acc.AccntBalance + amount;
            t.TransacId = 0;
            DB.transactions.Add(t);
            DB.accounts.Update(acc);
            DB.SaveChanges();
            return 2;
        }
        public List<Transaction> ViewStatment(int CusId, string type, DateTime From, DateTime To)
        {
            List<Transaction> transactions = new List<Transaction>();

            var tra = DB.transactions;
            foreach (Transaction t in tra)
            {
                if (type == "" || type == null)
                {
                    if (t.TransacDate > From && t.TransacDate < To)
                        transactions.Add(t);
                }
                else
                {
                    if (t.TransacDate > From && t.TransacDate < To && t.TransacType == type)
                        transactions.Add(t);
                }
            }
            return transactions.OrderByDescending(i=>i.TransacDate).ToList();
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
