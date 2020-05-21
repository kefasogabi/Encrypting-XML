﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Excercise02
{
    class Encryption
    {

        public void EncryptFile(string filePath, string key)
        {
            byte[] plainContent = File.ReadAllBytes(filePath);
            
            using (var DES = new DESCryptoServiceProvider())

            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(),
                    CryptoStreamMode.Write);
                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());
                    Console.WriteLine("Encrypted succesfully " + filePath);
                    
                }
                
            }
            
        }




        public void DecryptFile(string filePath, string key)
        {
            
            byte[] encrypted = File.ReadAllBytes(filePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;
                
                using (var memStream = new MemoryStream())
                {
                    
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(),
                        CryptoStreamMode.Write);
                    cryptoStream.Write(encrypted, 0, encrypted.Length);

                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());

                    Console.WriteLine("Decrypted succesfully " + filePath);
                }
            }
        }





    }
}
