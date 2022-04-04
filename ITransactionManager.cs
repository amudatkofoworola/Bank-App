using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp
{
    interface ITransactionManager
    {

        public void ReadTransactionFromFile();

        public void RefreshFile();

        public void AddToFile(Transaction transaction);

        public Transaction RegisterCustomerTransaction(string firstname, string surname, string accountNum, DateTime date, string activity, double amount, string details);

        public Transaction GetCustomerTransaction(string accountNum);
        public string GetCustomerTransactionDetails(string accountNum);

        public void AddNewTransactionDetails(string accountNum, DateTime date, string activity, double amount, double accountBalance);
        

        public void ShowCustomerTransactionDetails(string accountNum);
    }
}