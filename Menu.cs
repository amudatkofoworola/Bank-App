using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp
{
    class Menu
    {
        ICustomerManager customerManager = new CustomerManager();
        ITransactionManager transactionManager = new TransactionManager();

        CustomerTooYoungException exception = new CustomerTooYoungException();


        public void ShowMainMenu()
        {
            Console.WriteLine("Welcome to BT Bank");
            Console.WriteLine(" 1. Register");
            Console.WriteLine(" 2. Deposit funds");
            Console.WriteLine(" 3. Withdraw funds");
            Console.WriteLine(" 4. Transfer funds");
            Console.WriteLine(" 5. Change pin");
            Console.WriteLine(" 6. Update profile");
            Console.WriteLine(" 7. Transaction details");
            Console.WriteLine(" 8. Exit");

            Console.WriteLine("Select option: ");
            int option = int.Parse(Console.ReadLine());
            
            if(option<1 || option>7)
            {
                Console.WriteLine("Invalid input");
            }
                                  
            else if(option==1)
            {
                RegisterCustomerMenu();
            }
            else if(option==2)
            {
                DepositFundsMenu();
            }
            else if(option ==3)
            {
                WithdrawFundsMenu();
            }
            
            else if(option==4)
            {
                TransferFundsMenu();
            }
            else if(option==5)
            {
                ChangePinMenu();
            }
            else if(option==6)
            {
                UpdateProfileMenu();                
            }
            else if(option==7)
            {
                ShowTransactionDetails();                
            }
            else if(option==8)
            {
                ShowMainMenu();
            }
                 
        }


        public void RegisterCustomerMenu()
        {
            Console.WriteLine("Enter your firstname");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter your surname");
            string surname = Console.ReadLine();
            int gendervalue = 0;
            do
            {
                Console.WriteLine("Enter appropriate gender");
                Console.WriteLine("\tMale=1");
                Console.WriteLine("\tFemale = 2");
                gendervalue = int.Parse(Console.ReadLine());
            }
            while (gendervalue!=1 && gendervalue!=2);
            Gender gender = (Gender)gendervalue;
            Console.WriteLine("Enter your date of birth");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            
            try
            {
                customerManager.VerifyAge(dateOfBirth);
            }
            catch( CustomerTooYoungException ex)
            {
                 Console.WriteLine(ex.Message);                 
                 Console.WriteLine("Press any key to continue");
                 Console.ReadKey();
                 Console.WriteLine(" ");
                 ShowMainMenu();
                
            }

            Console.WriteLine("Enter your address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            string phonenumber = Console.ReadLine();            
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();            
            Console.WriteLine("Enter your next of Kin");
            string nextOfKin = Console.ReadLine();

            string pin = " ";
            string digits = "0123456789";
            do
            {
                Console.WriteLine("Enter your preferred four digit pin");
                pin = Console.ReadLine();
            } while (pin.Length<4 || pin.Length>4 ||( digits.IndexOf(pin[0])==-1 ||digits.IndexOf(pin[1])==-1  || digits.IndexOf(pin[2])==-1 || digits.IndexOf(pin[3])==-1));
            
            Customer newCustomer = customerManager.RegisterCustomer(firstname,surname, gender, dateOfBirth, address, phonenumber, email, nextOfKin, pin);
            customerManager.AddToFile(newCustomer);
            
            Console.WriteLine($"Dear {newCustomer.GetFullName()}, thank you for registering with BT Bank. Your Account Number is {newCustomer.GetAccountNum()}.");

            DateTime date = DateTime.Now;
            string activity = "Registration";
            double amount = 0;
            string details = "";
            
            Transaction newCustomerTransaction =transactionManager.RegisterCustomerTransaction(firstname, surname, newCustomer.GetAccountNum(), date, activity, amount, details);
            transactionManager.AddToFile(newCustomerTransaction);
            ShowMainMenu();

        }


        public void DepositFundsMenu()
        {
            Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();
            Customer customer = customerManager.GetCustomer(accountNum);

            if(customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                
                Console.WriteLine("How much do you want to deposit?");
                double amountDeposit = int.Parse(Console.ReadLine());
                if (amountDeposit<=0)
                {
                    Console.WriteLine("Amount entered less than zero");
                    ShowMainMenu();
                }
                customerManager.DepositFunds(accountNum, amountDeposit);
                transactionManager.AddNewTransactionDetails(accountNum, DateTime.Now, "deposit",amountDeposit,customer.GetAccountBalance());
            }
            ShowMainMenu();
        }


        public void WithdrawFundsMenu()
        {
            Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();

            if(customerManager.GetCustomer(accountNum) == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                Customer customer = customerManager.GetCustomer(accountNum);
                Console.WriteLine("Enter your pin");
                string pin = Console.ReadLine();
                if(customer.GetPin()!=pin)
                {
                    Console.WriteLine("Invalid pin");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("How much do you want to withdraw?");
                    int amountWithdaw = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Are you sure you want to withdraw {amountWithdaw}?");
                    string response = Console.ReadLine().ToLower();
                     if(response== "yes")
                    {
                        customerManager.WithdrawFunds(accountNum,pin,amountWithdaw);
                        transactionManager.AddNewTransactionDetails(accountNum, DateTime.Now, "Withdrawal",amountWithdaw,customer.GetAccountBalance());
                        
                    }
                    else
                    {
                        ShowMainMenu();
                    }
                }

            }
            ShowMainMenu();
        }


        public void TransferFundsMenu()
        {
            Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();
            Customer customer = customerManager.GetCustomer(accountNum);

            if(customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {               
                Console.WriteLine("Enter your pin");
                string pin = Console.ReadLine();
                if(customer.GetPin() != pin)
                {
                    Console.WriteLine("Invalid pin");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Enter your beneficiary account number");
                    string beneficiaryAccountNum = Console.ReadLine();
                    if(beneficiaryAccountNum==accountNum)
                    {
                        Console.WriteLine("Invalid transaction. you cant transfer to yourself");
                        ShowMainMenu();
                    }

                    Customer beneficiary = customerManager.GetCustomer(beneficiaryAccountNum);

                    if(beneficiary==null)
                    {
                        Console.WriteLine("Invalid beneficiary account number");
                        ShowMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("How much do you want to transfer?");
                        double amountTransfer = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Are you sure you want to transfer {amountTransfer} to {beneficiary.GetFullName()}?");
                        string response = Console.ReadLine().ToLower();
                        if(response== "yes")
                        {
                            Console.WriteLine($"Do you agree to a 2% charge on your transfer amount? Total deduction = {amountTransfer + amountTransfer*0.02}");
                            string resCharge = Console.ReadLine().ToLower();
                            if(resCharge=="yes")
                            {
                                customerManager.TransferFunds(accountNum,pin, beneficiaryAccountNum,amountTransfer);
                                transactionManager.AddNewTransactionDetails(accountNum, DateTime.Now, "Transfer",amountTransfer,customer.GetAccountBalance());
                                transactionManager.AddNewTransactionDetails(beneficiaryAccountNum, DateTime.Now, "Received by Transfer",amountTransfer,beneficiary.GetAccountBalance());
                            }
                            else
                            {
                                ShowMainMenu();
                            }
                            
                        }
                        else
                        {
                            ShowMainMenu();
                        }
                    }

             
                }
            }
            ShowMainMenu();
        }


        public void ChangePinMenu()
        {
            Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();
            Customer customer = customerManager.GetCustomer(accountNum);

            if(customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                Console.WriteLine("Enter your pin");
                string pin = Console.ReadLine();
                if(customer.GetPin() != pin)
                {
                    Console.WriteLine("Invalid pin");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Are you sure you want to change your pin?");
                    string response = Console.ReadLine().ToLower();
                    if(response == "yes")
                    {
                        Console.WriteLine("Enter your new Pin");
                        string newPin = Console.ReadLine();
                        customerManager.ChangePin(accountNum, pin, newPin);
                    }
                    else
                    {
                        ShowMainMenu();
                    }
                }
            }
            ShowMainMenu();
        }



        public void UpdateProfileMenu()
        {
            Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();
            Customer customer = customerManager.GetCustomer(accountNum);

            if(customer == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                Console.WriteLine("Enter your pin");
                string pin = Console.ReadLine();
                if(customer.GetPin() != pin)
                {
                    Console.WriteLine("Invalid pin");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Do you want to change your first name?");
                    string resFirstName = Console.ReadLine().ToLower();
                    if (resFirstName=="yes")
                    {
                        Console.WriteLine("Enter your new first name");
                        string newFirstName = Console.ReadLine();
                        customerManager.ChangeFirstName(accountNum, newFirstName);
                    }
                    Console.WriteLine("Do you want to change your surname?");
                    string resSurname = Console.ReadLine().ToLower();
                    if (resSurname=="yes")
                    {
                        Console.WriteLine("Enter your new surname");
                        string newSurname = Console.ReadLine();
                        customerManager.ChangeSurname(accountNum, newSurname);
                    }
                    Console.WriteLine("Do you want to change your gender?");
                    string resGender = Console.ReadLine().ToLower();
                    if(resGender == "yes")
                    {
                        int newGenderValue = 0;
                        do
                        {
                            Console.WriteLine("Enter appropriate gender");
                            Console.WriteLine("\tMale=1");
                            Console.WriteLine("\tFemale = 2");
                            newGenderValue = int.Parse(Console.ReadLine());
                        }
                        while (newGenderValue!=1 && newGenderValue!=2);
                        Gender newGender = (Gender)newGenderValue;
                        customerManager.ChangeGender(accountNum,newGender);
                    }
                    Console.WriteLine("Do you want to change your date of birth?");
                    string resDateOfBirth = Console.ReadLine().ToLower();
                    if(resDateOfBirth=="yes")
                    {
                        Console.WriteLine("Enter your new date of birth");
                        DateTime newDateOfBirth = Convert.ToDateTime(Console.ReadLine());
                        customerManager.ChangeDateOfBirth(accountNum,newDateOfBirth);
                    }
                    Console.WriteLine("Do you want to change your address?");
                    string resAddress = Console.ReadLine().ToLower();
                    if(resAddress=="yes")
                    {
                        Console.WriteLine("Enter new address");
                        string newAddress = Console.ReadLine();
                        customerManager.ChangeAddress(accountNum,newAddress);
                    }
                    Console.WriteLine("Do you want to change your phone number?");
                    string resPhoneNum = Console.ReadLine().ToLower();
                    if(resPhoneNum == "yes")
                    {
                        Console.WriteLine("Enter your new phone number");
                        string newPhoneNum = Console.ReadLine();
                        customerManager.ChangePhoneNum(accountNum,newPhoneNum);
                    }
                    Console.WriteLine("Do you want to change your email?");
                    string resEmail = Console.ReadLine().ToLower();
                    if(resEmail=="yes")
                    {
                        Console.WriteLine("Enter your new email");
                        string newEmail = Console.ReadLine();
                        customerManager.ChangeEmail(accountNum, newEmail);
                    }
                    Console.WriteLine("Do you want to change your next of Kin?");
                    string resNextOfKin = Console.ReadLine().ToLower();
                    if(resNextOfKin =="yes")
                    {
                        Console.WriteLine("Enter your new Next of Kin");
                        string newNextOfKin = Console.ReadLine();
                        customerManager.ChangeNextOfKin(accountNum, newNextOfKin);
                    }
                    customerManager.RefreshFile(); 
                    Console.WriteLine("Dear customer, you updates are successfully saved");                  
                                                   
                                   
                }    
            }           

            
            ShowMainMenu();
               
        }


        public void ShowTransactionDetails()
        {
             Console.Write("Enter your account number: ");
            string accountNum = Console.ReadLine();
            Transaction customerTransaction = transactionManager.GetCustomerTransaction(accountNum);

            if(customerTransaction == null)
            {
                Console.WriteLine("This customer does not exist");
            }
            else
            {
                transactionManager.ShowCustomerTransactionDetails(accountNum);
            }
            ShowMainMenu();
        }






    }



}