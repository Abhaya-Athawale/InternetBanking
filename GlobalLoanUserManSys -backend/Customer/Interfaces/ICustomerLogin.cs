﻿using Customer.Entity;

namespace Customer.Interfaces
{
    public interface ICustomerLogin
    {
        List<customerLogin> GetAll();
        customerLogin GetbyId(int id);

        customerLogin Add(customerLogin customer);
        void Edit(customerLogin customer);

        void Delete(int id);
        string GenerateToken(customerLogin cus);
        customerLogin login(customerLogin cus);

    }
}
