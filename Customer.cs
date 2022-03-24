using System;

namespace ProjectBankApp
{

    class Customer
    {
        private string _firstName;
        private string _surname;
        private Gender _gender;
        private DateTime _dateOfBirth;
        private string _address;
        private string _phoneNo;
        private string _email;
        private string _nextOfKin;
       
        private string _customerPin;
        private string _accountNum;
        private double _accountBalance;
        



        public Customer(string firstName, string surname, Gender gender, DateTime dateOfBirth, string address, string phoneNo, string email, string nextOfKin, string Pin, string accountNum)
        {
            _firstName = firstName;
            _surname = surname;
            _gender =gender;
            _dateOfBirth = dateOfBirth;
            _address = address;
            _phoneNo = phoneNo;
            _email = email;
            _nextOfKin = nextOfKin;
            _customerPin = Pin;
            _accountNum = accountNum;
            _accountBalance = 0;
            

        }


        public string GetAccountNum()
        {
            return _accountNum;
        }


        public string GetFullName()
        {
            return _firstName+" "+_surname;
        }


        public double GetAccountBalance()
        {
            return _accountBalance;
        }
        
        public void SetAccountBalance(double newBalance)
        {
             _accountBalance=newBalance;
             
        }

        public string GetPin()
        {
            return _customerPin;
        }


        public void SetPin(string newPin)
        {
             _customerPin= newPin;
             
        }


        

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string newFirstName)
        {
            _firstName = newFirstName;
            
        }


        public string GetSurname()
        {
            return _surname;
        }

        public void SetSurname(string newSurname)
        {
            _surname = newSurname;
          
        }


        public Gender GetGender()
        {
            return _gender;
        }

        public void SetGender(Gender newGender)
        {
            _gender = newGender;
          
        }


        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public void SetDateOfBirth(DateTime newDateOfBirth)
        {
            _dateOfBirth = newDateOfBirth;
            
        }


        public string GetAddress()
        {
            return _address;
        }

        public void SetAddress(string newAddress)
        {
            _address = newAddress;
            
        }

        public string GetPhoneNum()
        {
            return _phoneNo;
        }

        public void SetPhoneNum(string newPhoneNum)
        {
            _phoneNo = newPhoneNum;
            
        }


        public string GetEmail()
        {
            return _email;
        }

        public void SetEmail(string newEmail)
        {
            _email = newEmail;
            
        }

        public string GetNextOfKin()
        {
            return _nextOfKin;
        }

        public void SetNextOfKIn(string newNextOfKin)
        {
            _nextOfKin = newNextOfKin;
            
        }





    }
    

}