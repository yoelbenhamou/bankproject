using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_project
{
    class Bank : ibank

    {
        private List<Account> accounts = new List<Account>();

        private List<Customer> customers = new List<Customer>();

        private Dictionary<int, Customer> dictionaryID = new Dictionary<int, Customer>();

        private Dictionary<int, Customer> dictionaryCustNumber = new Dictionary<int, Customer>();

        private Dictionary<int, Account> dictionaryAccNumber = new Dictionary<int, Account>();

        private Dictionary<Customer, List<Account>> dictionaryCustomers = new Dictionary<Customer, List<Account>>();



        internal void JoinAccounts(Account account1, Account account2)
        {
            throw new NotImplementedException();
        }

        internal void CloseAccount(Account account3, Customer aurel)
        {
            throw new NotImplementedException();
        }

        private int totalMoneyInBank = 0;

        private int profits = 0;
        private string v1;
        private int v2;
        private string v3;

        public Bank(string v1, int v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public string Adress { get; set; }

        public string adress => throw new NotImplementedException();

        public int CustomerCount { get; set; }

        public string Name { get; set; }

        internal Customer GetCustomerByID(int customerid)
        {
            if (dictionaryID.TryGetValue(customerid, out Customer customer))
            {
                return customer;
            }
            else
            {
                throw new CustomerNotFoundException($"The costumer ID number{customerid} not in our bank");
            }

        }

        internal Account GetAccountByNumber(int accountNumber)
        {
            if (dictionaryAccNumber.TryGetValue(accountNumber, out Account account))
            {
                return account;
            }
            else
            {
                throw new AccountNotFoundException($"The account number{accountNumber} not in our bank");
            }
        }
        internal List<Account> GetAccountsByCustomer(Customer customer)
        {
            if (dictionaryCustomers.TryGetValue(customer, out List<Account> accounts))
            {
                return accounts;
            }
            else
            {
                throw new AccountNotFoundException($"The costumer {customer} dont have accounts in our bank");
            }
        }
        internal void AddNewCustomer(Account account1, Customer customer)
        {
            if (customers.Contains(customer))
            {
                throw new CustomerAlreadyExistException($"The customer {customer.Name} already exist in our bank");
            }
            customers.Add(customer);
            dictionaryID.Add(customer.CustomerID, customer);
            dictionaryCustNumber.Add(customer.CustomerNumber, customer);

        }
        internal void OpenNewAccount(Account account, Customer customer)
        {
            if (this.accounts.Contains(account))
            {
                throw new AccountAlreadyExistException($"The account {account.accountNumber} already exist in our bank");
            }
            this.accounts.Add(account);
            dictionaryAccNumber.Add(account.accountNumber, account);
            totalMoneyInBank = totalMoneyInBank + account.Balance;
            if (dictionaryCustomers.TryGetValue(customer, out List<Account> accounts1))
            {
                accounts1.Add(account);
            }
            else
            {
                dictionaryCustomers.Add(customer, this.accounts);
            }
        }


    }
        internal int GetCostumerTotalBalance(Customer customer)
        {
            int CostumerTotalBalance = 0;
            foreach (Account item in GetAccountsByCustomer(customer))
            {
                CostumerTotalBalance = CostumerTotalBalance + item.Balance;
            }
            return CostumerTotalBalance;
        }
        internal int Withdraw(Account account, int amoumt)
        {
            totalMoneyInBank = totalMoneyInBank - amoumt;
            account.Substract(amoumt);
            if (account.Balance < account.MaxMinusAllowed)
            {
                throw new BalanceException($"The account {account} went out from the minus");
            }
            return account.Balance;
        }

        internal void CloseAccount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                accounts.Remove(account);
                dictionaryAccNumber.Remove(account.AccountOwner);
                if (dictionaryCustomers.TryGetValue(customer, out List<Account> accounts1))
                {
                    if (accounts1.Count == 1)
                    {
                        dictionaryCustomers.Remove(customer);
                        customers.Remove(customer);
                        dictionaryCustomers.Remove(customer);
                        dictionaryCustNumber.Remove(customer.CustomerNumber);
                    }
                    else
                    {
                        accounts1.Remove(account);
                    }
                }


                totalMoneyInBank = totalMoneyInBank - account.Balance;
            }

        }


    }
}
