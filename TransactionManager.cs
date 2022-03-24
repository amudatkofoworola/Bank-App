using System;

namespace ProjectBankApp
{
    class TransactionManager : ITransactionManager
    {
        private Transaction[] _customerTransction = new Transaction[100];
        private int _noOfCustomers = 0;
        


        public Transaction RegisterCustomerTransaction(DateTime date, string activity, double amount, double accountBalance)
        {
            
            Transaction newCustomerTransaction = new Transaction(accountNum, date, activity, amount, accountBalance);
            _customerTransction[_noOfCustomers] = newCustomerTransaction;
            _noOfCustomers++;

            return newCustomerTransaction;
        }
    }
}