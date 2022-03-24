using System;

namespace ProjectBankApp
{
    class Transaction
    {
        private DateTime _dateOfTransaction;
        private string _activity;
        private double _amount;
        private double _accountBalance;


        public Transaction(string accountNum, DateTime date, string activity, double amount, double accountBalance)
        {
            _dateOfTransaction = date;
            _activity = " ";
            _amount = 0;
            _accountBalance = 0;
        }


    }
}