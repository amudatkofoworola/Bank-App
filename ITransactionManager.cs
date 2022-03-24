using System;

namespace ProjectBankApp
{
    interface ITransactionManager
    {
        public Transaction RegisterCustomerTransaction(string accountNum, DateTime date, string activity, double amount, double accountBalance);
    }
}