using System;

namespace ProjectBankApp
{
    interface ITransactionManager
    {
        public Transaction RegisterCustomerTransaction(string firstname, string surname, string accountNum, DateTime date, string activity, double amount);

        public Transaction GetCustomerTransaction(string accountNum);

        public void AddNewTransactionDetails(string accountNum, DateTime date, string activity, double amount, double _accountBalance);

        public void ShowCustomerTransactionDetails(string accountNum);
    }
}