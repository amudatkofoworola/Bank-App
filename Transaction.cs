using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp
{
    class Transaction
    {
        private string _firstName;
        private string _surname;
        private string _accountNum;
        private DateTime _dateOfTransaction;
        private string _details;
       


        // public Transaction(string firstname, string surname, string accountNum, DateTime date, string details)
        // {
        //     _firstName = firstname;
        //     _surname = surname;
        //     _accountNum = accountNum;
        //     _dateOfTransaction = date;
        //     _details = details;
           
        // }
        public override string ToString()
        {
            return $"{_firstName}\t{_surname}\t{_accountNum}\t{_dateOfTransaction}\t{_details}";
        }

        public static Transaction ToTransaction(string str)
        {
            var transactionString = str.Split("\t");
            string _firstName = transactionString[0];
            string _surname = transactionString[1];
            string _accountNum = transactionString[2];
            DateTime _dateOfTransction = Convert.ToDateTime(transactionString[3]) ;
           string _details = transactionString[4];
           Transaction transaction = new Transaction(_firstName, _surname, _accountNum, _dateOfTransction,_details);
           return transaction;
        }

        public Transaction(string firstName, string surname, string accountNum, DateTime dateOfTransaction, string details)
        {
            _firstName = firstName;
            _surname = surname;
            _accountNum = accountNum;
            _dateOfTransaction = dateOfTransaction;
            _details = details;
            

        }



        public string GetAccountNum()
        {
            return _accountNum;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_surname}";
        }


        public string GetDetails()
        {
            return _details;
        }

        public void SetDetails( string newdetails)
        {
            _details = newdetails;
        }




    }
}