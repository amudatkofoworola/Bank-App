using System;

namespace ProjectBankApp
{
    class CustomerTooYoungException :Exception
    {

        public  CustomerTooYoungException()
        {
            
        }
         public  CustomerTooYoungException(string message) : base(message)
         {
            
         }
        // public  CustomerTooYoungException(DateTime dateOfBirth)
        // {
        //     Console.WriteLine("Customer is too young to open a bank account");
           
                       
        // }
    }
}
