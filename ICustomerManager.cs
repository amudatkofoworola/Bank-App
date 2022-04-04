using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp
{
    interface ICustomerManager
    {

        public void ReadCustomerFromFile();
        public void RefreshFile();

        public void AddToFile(Customer customer);

        public void VerifyAge(DateTime dateOfBirth);

        public Customer GetCustomer(string accountNum);

        public string GetCustomerPin(string accountNum);

        public Customer RegisterCustomer(string firstName, string surname, Gender gender, DateTime dateOfBirth, string address, string phoneNo, string email, string nextOfKin, string Pin);
        

        public void DepositFunds(string accountNum, double amountDeposit);

        public void WithdrawFunds(string accountNum, string pin, int amountWithdaw);

       
        public void TransferFunds(string accountNum, string pin, string beneficiaryAccountNum, double amountTransfer);

        public void ChangePin(string accountNum, string pin, string newPin);

        public void ChangeFirstName(string accountNum, string newFirstName);
        public void ChangeSurname(string accountNum, string newSurname);

        public void ChangeGender(string accountNum, Gender newGender);

        public void ChangeDateOfBirth(string accountNum, DateTime newDateOfBirth);

        public void ChangeAddress(string accountNum, string newAddress);

        public void ChangePhoneNum(string accountNum, string newPhoneNum);

        public void ChangeEmail(string accountNum, string newEmail);

        public void ChangeNextOfKin(string accountNum, string newNextOfKin);
    }
}