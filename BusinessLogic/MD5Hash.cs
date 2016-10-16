using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PublicEventsManager.BusinessLogic
{
    public static class MD5Hash
    {
        /// <summary>
        /// MD5 algorithm is used as a cryptographic hash function to encrypt password in databse.
        /// </summary>
        /// <param name="input">Text which has to be encrypted.</param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {
            using (MD5 cryptoServiceProvider = new MD5CryptoServiceProvider())
            {
                byte[] encoded = cryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));

                StringBuilder hashCode = new StringBuilder();

                foreach(var item in encoded)
                {
                    hashCode.Append(item.ToString("X2"));
                }
                return hashCode.ToString();
            }
        }
    }
}
