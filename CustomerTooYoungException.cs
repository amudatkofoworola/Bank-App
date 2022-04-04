using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
