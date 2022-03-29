using System;

namespace ProjectBankApp
{
    class Transaction
    {
        private string _firstName;
        private string _surname;
        private string _accountNum;
        private DateTime _dateOfTransaction;
        private string _details;
       


        public Transaction(string firstname, string surname, string accountNum, DateTime date, string details)
        {
            _firstName = firstname;
            _surname = surname;
            _accountNum = accountNum;
            _dateOfTransaction = date;
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