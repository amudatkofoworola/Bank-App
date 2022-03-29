using System;

namespace ProjectBankApp
{
    class TransactionManager : ITransactionManager
    {
        private Transaction[] _customerTransction = new Transaction[100];
        private int _noOfCustomers = 0;

        
        


        public Transaction RegisterCustomerTransaction(string firstname, string surname, string accountNum, DateTime date, string activity, double amount, string details)
        {
            details = "";
            
            Transaction newCustomerTransaction = new Transaction(firstname, surname, accountNum, date, details);
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

        public string GetCustomerTransactionDetails(string accountNum)
        {
            Transaction customerTransaction = GetCustomerTransaction(accountNum);
            if (customerTransaction == null)
            {
                return "This customer does not exist";
            }
            else
            {
                return customerTransaction.GetDetails();
            }

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
                string y = customerTransaction.GetDetails();
               
                y+= $"{date}       {activity}      {amount}        {accountBalance}.\n";
                customerTransaction.SetDetails(y);         

                              
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
                Console.WriteLine(customerTransaction.GetDetails());
            }  
        }



    }
}