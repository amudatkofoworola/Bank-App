using System;

namespace ProjectBankApp
{
    class Transaction
    {
        private string _firstName;
        private string _surname;
        private string _accountNum;
        private DateTime _dateOfTransaction;
       


        public Transaction(string firstname, string surname, string accountNum, DateTime date)
        {
            _firstName = firstname;
            _surname = surname;
            _accountNum = accountNum;
            _dateOfTransaction = date;
           
        }


        public string GetAccountNum()
        {
            return _accountNum;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_surname}";
        }


    }
}