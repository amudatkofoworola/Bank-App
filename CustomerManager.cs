using System;

namespace ProjectBankApp
{

    
    class CustomerManager: ICustomerManager
   
    {
        private Customer[] _customers = new Customer[100];
        private int _noOfCustomers = 0;
        Random rand = new Random();

        CustomerTooYoungException exception = new CustomerTooYoungException();




        public void VerifyAge(DateTime dateOfBirth)
        {
            int age = (DateTime.Now.Subtract(dateOfBirth).Days)/365;
            if (age<16)
            {
                throw new CustomerTooYoungException("Customer is too young to open a bank account");
            }
            
            
        }

        private string GenerateAccountNum()
        {
            string c1 = rand.Next(0,100000).ToString("00000");
            string c2 = rand.Next(0,100000).ToString("00000");
            string accountNum = $"{c1}{c2}";
            return accountNum;
        }


        public Customer GetCustomer(string accountNum)
        {
            for(int y = 0; y<_noOfCustomers; y++)
            {
                if (_customers[y].GetAccountNum() == accountNum)
                {
                    return _customers[y];
                }
            }
            return null;
        }



        public string GetCustomerPin(string accountNum)
        {
            for(int y = 0; y<_noOfCustomers; y++)
            {
                if (_customers[y].GetAccountNum() == accountNum)
                {
                    return _customers[y].GetPin();
                }
            }
            return "";
        }

        public Customer RegisterCustomer(string firstName, string surname, Gender gender, DateTime dateOfBirth, string address, string phoneNo, string email, string nextOfKin, string Pin)
        {
            string accountNum = GenerateAccountNum();
           
            Customer customer = new Customer(firstName, surname, gender, dateOfBirth, address, phoneNo, email, nextOfKin, Pin, accountNum);
            _customers[_noOfCustomers] = customer;
            _noOfCustomers++;

            return customer;
        }


        public void DepositFunds(string accountNum, double amountDeposit)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                double newBalance = customer.GetAccountBalance()+amountDeposit;
                customer.SetAccountBalance(newBalance);
                Console.WriteLine($"Thank you {customer.GetFullName()}. Funds succesfully deposited. Your new account balance is {customer.GetAccountBalance()}.");
            }
        }


        public void WithdrawFunds(string accountNum, string pin, int amountWithdaw)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                if (customer.GetPin()==pin)
                {
                    if(customer.GetAccountBalance()<amountWithdaw)
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                    else
                    {
                        double newBalance = customer.GetAccountBalance() - amountWithdaw;
                        customer.SetAccountBalance(newBalance);
                        Console.WriteLine($"Thank you {customer.GetFullName()}. Withdrawal succesful. Your new account balance is {customer.GetAccountBalance()}.");
                    }
                }
            }
            
        }

      

        public void TransferFunds(string accountNum, string pin, string beneficiaryAccountNum, double amountTransfer)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                if (customer.GetPin()==pin)
                {
                    Customer beneficiary = GetCustomer(beneficiaryAccountNum);
                    if (beneficiary == null)
                    {
                       Console.WriteLine("This customer does not exist");
                    }
                    else
                    {
                         if(customer.GetAccountBalance() <(amountTransfer + (amountTransfer*0.02)))
                        {
                            Console.WriteLine("Insufficient funds");
                        }
                        else
                        {
                            double newCustomerBalance = customer.GetAccountBalance() - (amountTransfer + (amountTransfer*0.02));
                            customer.SetAccountBalance(newCustomerBalance);
                            double newBeneficiaryBalance = beneficiary.GetAccountBalance() + amountTransfer;
                            beneficiary.SetAccountBalance(newBeneficiaryBalance);
                            Console.WriteLine($"Thank you {customer.GetFullName()}. Funds succesfully transferred to {beneficiary.GetFullName()}:{beneficiary.GetAccountNum()}. Your new account balance is {customer.GetAccountBalance()}." );
                        }
                    }
                }
            }
        }


        public void ChangePin(string accountNum, string pin, string newPin)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                if (customer.GetPin()==pin)
                {
                    customer.SetPin(newPin);
                    Console.WriteLine($"Thank you {customer.GetFullName()}. Pin succesfully changed. Your new Pin is {customer.GetPin()}.");
                }
            }
        }


        public void ChangeFirstName(string accountNum,string newFirstName)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetFirstName(newFirstName);
                Console.WriteLine($"First name succesfully changed. Your new first name is {customer.GetFirstName()}.");
                
            }
        }

        public void ChangeSurname(string accountNum, string newSurname)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetSurname(newSurname);
                Console.WriteLine($"Surname succesfully changed. Your new first name is {customer.GetSurname()}.");
                
            }
        }

        public void ChangeGender(string accountNum, Gender newGender)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetGender(newGender);
                Console.WriteLine($"Gender succesfully changed. Your current gender is {customer.GetGender()}.");
                
            }
        }


        public void ChangeDateOfBirth(string accountNum, DateTime newDateOfBirth)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetDateOfBirth(newDateOfBirth);
                Console.WriteLine($"Date of Birth succesfully changed. Your new Date of Birth is {customer.GetDateOfBirth()}.");
                
            }
        }

        public void ChangeAddress(string accountNum, string newAddress)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetAddress(newAddress);
                Console.WriteLine($"Address succesfully changed. Your new Address is {customer.GetAddress()}.");
                
            }
        }


        public void ChangePhoneNum(string accountNum, string newPhoneNum)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetPhoneNum(newPhoneNum);
                Console.WriteLine($"Phone number succesfully changed. Your new phone number is {customer.GetPhoneNum()}.");
                
            }
        }


        public void ChangeEmail(string accountNum, string newEmail)
        {
             Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetEmail(newEmail);
                Console.WriteLine($"Email succesfully changed. Your new email is {customer.GetEmail()}.");
                
            }
        }


        public void ChangeNextOfKin(string accountNum, string newNextOfKin)
        {
            Customer customer = GetCustomer(accountNum);
            if (customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {

                customer.SetEmail(newNextOfKin);
                Console.WriteLine($"Next of Kin details succesfully changed. Your new Next of Kin is {customer.GetNextOfKin()}.");
                
            }
        }






    }
}