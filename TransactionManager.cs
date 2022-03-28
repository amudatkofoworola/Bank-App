using System;

namespace ProjectBankApp
{
    class TransactionManager : ITransactionManager
    {
        private Transaction[] _customerTransction = new Transaction[100];
        private int _noOfCustomers = 0;

        private string transactionDetails = " ";
        


        public Transaction RegisterCustomerTransaction(string firstname, string surname, string accountNum, DateTime date, string activity, double amount)
        {
            
            Transaction newCustomerTransaction = new Transaction(firstname, surname, accountNum, date);
            _customerTransction[_noOfCustomers] = newCustomerTransaction;
            _noOfCustomers++;

            return newCustomerTransaction;
        }

        public Transaction GetCustomerTransaction(string accountNum)
        {
            for(int y = 0; y<_noOfCustomers; y++)
            {
                if (_customerTransction[y].GetAccountNum() == accountNum)
                {
                    return _customerTransction[y];
                }
            }
            return null;
        }


        public void AddNewTransactionDetails(string accountNum, DateTime date, string activity, double amount, double accountBalance)
        {
            Transaction customerTransaction = GetCustomerTransaction(accountNum);
            if (customerTransaction == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                
                transactionDetails+= $"{date}       {activity}      {amount}        {accountBalance}.\n";
                
               
            }
           

        }

        public void ShowCustomerTransactionDetails(string accountNum)
        {
              Transaction customerTransaction = GetCustomerTransaction(accountNum);
            if (customerTransaction == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                Console.WriteLine($"Dear {customerTransaction.GetFullName()}, find below your transaction details.");
                Console.WriteLine(transactionDetails);
            }  
        }



    }
}