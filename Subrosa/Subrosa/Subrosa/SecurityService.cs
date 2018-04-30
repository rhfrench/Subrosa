using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Subrosa
{
    public class SecurityService
    {
        private const string _salt = "123456ThisIsASalt66642069"; 
        private SHA256Managed _hash;
        

        public SecurityService()
        {


            _hash = new SHA256Managed();

            
        }

        public string EncryptString(string input)
        {
            MemoryStream memoryStream;
            CryptoStream cryptoStream;

            if (String.IsNullOrWhiteSpace(input))
                return "";

            return "";
        }
        
        public string DecryptString(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return "";


            return "";
        }
    }
}
