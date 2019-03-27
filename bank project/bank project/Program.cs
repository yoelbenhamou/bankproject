using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer yoel = new Customer(1, "yoel", 999);


            Customer ben = new Customer(2, "ben", 777);

            Customer aurel = new Customer(3, "aurel", 888);
            Account account1 = new Account(yoel, 3500, 7000);
            Account account2 = new Account(ben, 4500, 8000);
            Account account3 = new Account(aurel, 5000, 100000);
            Bank bank = new Bank("ashdod", 22, "hapoalim");

            bank.AddNewCustomer(account1, yoel);

            bank.OpenNewAccount(account1, yoel);

            bank.JoinAccounts(account1, account2);

            bank.OpenNewAccount(account2, yoel);
         
            try
            {
                bank.CloseAccount(account2, ben);
            }
            catch (AccountNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            try
            {
                bank.GetCustomerByID(777);
            }
            catch (CustomerNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
