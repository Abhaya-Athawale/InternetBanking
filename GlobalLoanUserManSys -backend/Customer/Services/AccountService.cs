using Customer.Database;
using Customer.Entity;
using Customer.Interfaces;

namespace Customer.Services
{
    public class AccountService :InterfaceAccount
    {
        private readonly DBContext DB;
        public AccountService()
        {
            DB = new DBContext();
        }

        public List<Account> GetAllAccnts()
        {
            return DB.accounts.ToList();
        }

        public Account GetAccntbyId(int id)
        {
            return DB.accounts.FirstOrDefault(i => i.AccntId == id); ;
        }

        public void AddAccnt(Account account)
        {
            DB.accounts.Add(account);
            DB.SaveChanges();
        }

        public void DeleteAccnt(int id)
        {
            DB.accounts.Remove(DB.accounts.Find(id));
            DB.SaveChanges();
        }

        public int ApplyLoan(int id, string branch, int amount)
        {
            if(amount<0||amount >100000)
                return 3;
            Account acc =  DB.accounts.FirstOrDefault(i => i.CustomerId == id);
            if(acc==null)
                return 0;
            else if (acc.Branch != branch)
                return 1;
            else
            {
                acc.AccntBalance = acc.AccntBalance + amount;
                
                Transaction t = new Transaction();
                t.AccntId = acc.AccntId;
                t.CustomerId = id;
                t.TransacDate = DateTime.Now;
                t.TransacType = "Deposit";
                t.TransacAmnt = amount;
                t.TransacId = 0;
                DB.transactions.Add(t);
                DB.accounts.Update(acc);
                DB.SaveChanges();
                return 2;

            }
            return 0;
        }

        public void EditAccnt(int Accntid, Account account)
        {
            Account EditedAccnt = DB.accounts.Find(Accntid);
            if (EditedAccnt != null)
            {
                DB.accounts.Update(EditedAccnt).CurrentValues.SetValues(account);
                DB.SaveChanges();
            }
        }
    }
}
