using Customer.Entity;

namespace Customer.Interfaces
{
    public interface InterfaceAccount
    {
        
        
            List<Account> GetAllAccnts();
            Account GetAccntbyId(int id);

            void AddAccnt(Account account);
            void EditAccnt(int Accntid,Account account);

            void DeleteAccnt(int id);

            int ApplyLoan(int id, string branch, int amount);

        

       

}
}
