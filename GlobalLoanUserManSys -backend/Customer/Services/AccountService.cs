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
