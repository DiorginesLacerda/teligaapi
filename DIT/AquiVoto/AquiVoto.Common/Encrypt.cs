using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AquiVoto.Common
{
    public static class Encrypt
    {
        //SOURCE: http://www.codeshare.co.uk/blog/sha-256-and-sha-512-hash-examples/

        //THE APPLICATION IS USING SHA256 AT MOMENT TO GENERATE THE ENCRYPT
        public static string GenerateSHA256String(string inputString)
        {
            //salt on password.
            inputString += ConfigurationManager.AppSettings["SALT_KEY"];

            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        //DON'T DELETE THE CODE FOR SHA512 YET.
        //public static string GenerateSHA512String(string inputString)
        //{
        //    SHA512 sha512 = SHA512Managed.Create();
        //    byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        //    byte[] hash = sha512.ComputeHash(bytes);
        //    return GetStringFromHash(hash);
        //}

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
