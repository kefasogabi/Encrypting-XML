using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Customer customer = new Customer();
            customer.Name = "Bob Smith";
            customer.CreditCard = "1234-5678-9012-3456";
            customer.Password = "pa$$w0rd";


            var path = @"C:\Test\card.xml";
            var key = "hwxkwtyp";

            try
            {

                
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xSer = new XmlSerializer(typeof(Customer));


                    xSer.Serialize(fs, customer);
                };


                var encrypt = new Encryption();

                encrypt.EncryptFile(path, key);
                

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        
    }
}
