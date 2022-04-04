using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp
{
    class TransactionManager : ITransactionManager
    {
        // private Transaction[] _customerTransction = new Transaction[100];
        // private int _noOfCustomers = 0;

        List<Transaction> transactions= new List<Transaction>();
        string fileName = "C:\\Users\\BIMBOLA\\Desktop\\New folder\\ProjectBankApp\\Files\\transactions.txt";

        public TransactionManager()
        {
        
            ReadTransactionFromFile();
        }

        public void ReadTransactionFromFile()
        {
           try
           {
                if(File.Exists(fileName))
                {
                    var allTransactions = File.ReadAllLines(fileName);
                    foreach(var transaction in allTransactions)
                    {
                        transactions.Add(Transaction.ToTransaction(transaction));
                    }
                  
                }
                else
                {
                    string path = "C:\\Users\\BIMBOLA\\Desktop\\New folder\\ProjectBankApp\\Files";
                    Directory.CreateDirectory(path);
                    string newFileName = "transactions.txt";
                    string fullPath = Path.Combine(path, newFileName);
                    using (File.Create(fullPath)) { }
                }
           }
           catch(Exception e)
           {
               Console.WriteLine(e.Message);
           }
        }

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(fileName))
                {
                    foreach (var transaction in transactions)
                    {
                        sr.WriteLine(transaction.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddToFile(Transaction transaction)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(fileName, true))
                {
                    sr.WriteLine(transaction.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        


        public Transaction RegisterCustomerTransaction(string firstname, string surname, string accountNum, DateTime date, string activity, double amount, string details)
        {
            details = "";
            
            Transaction newCustomerTransaction = new Transaction(firstname, surname, accountNum, date, details);
            // _customerTransction[_noOfCustomers] = newCustomerTransaction;
            // _noOfCustomers++;

            transactions.Add(newCustomerTransaction);

            return newCustomerTransaction;
        }

        public Transaction GetCustomerTransaction(string accountNum)
        {

            foreach(var transaction in transactions)
            {
                 if (transaction.GetAccountNum() == accountNum)
                {
                    return transaction;
                }
            }
            // for(int y = 0; y<_noOfCustomers; y++)
            // {
            //     if (_customerTransction[y].GetAccountNum() == accountNum)
            //     {
            //         return _customerTransction[y];
            //     }
            // }
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
               
                y+= $"{date}       {activity}               {amount}            {accountBalance}.\n";
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