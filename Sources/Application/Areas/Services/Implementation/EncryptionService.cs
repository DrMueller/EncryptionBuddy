using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.Services.Servants;

namespace Mmu.EncryptionBuddy.Areas.Services.Implementation
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IRijndaelFactory _rijndaelFactory;

        public EncryptionService(IRijndaelFactory rijndaelFactory)
        {
            _rijndaelFactory = rijndaelFactory;
        }

        // https://stackoverflow.com/questions/1629828/how-to-encrypt-a-string-in-net
        public async Task<string> DescryptAsync(string cipherText)
        {
            var rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Key = ProvideKey();
            rijndaelCipher.IV = ProvideInitialVector();

            var memoryStream = new MemoryStream();
            var rijndaelDecryptor = rijndaelCipher.CreateDecryptor();
            var cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);

            var plainText = string.Empty;

            try
            {
                var cipherBytes = Convert.FromBase64String(cipherText);

                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                cryptoStream.FlushFinalBlock();
                var plainBytes = memoryStream.ToArray();

                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }

            return plainText;
        }

        public async Task<string> EncryptAsync(string plainText)
        {
            var rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Key = ProvideKey();
            rijndaelCipher.IV = ProvideInitialVector();

            var memoryStream = new MemoryStream();
            var rijndaelEncryptor = rijndaelCipher.CreateEncryptor();
            var cryptoStream = new CryptoStream(memoryStream, rijndaelEncryptor, CryptoStreamMode.Write);
            var plainBytes = Encoding.ASCII.GetBytes(plainText);

            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();

            var cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
            return cipherText;
        }

        private byte[] ProvideInitialVector()
        {
            var t = new string('t', 16);
            var enc = new ASCIIEncoding();
            var bytes = enc.GetBytes(t);

            return bytes;
        }

        private  byte[] ProvideKey()
        {
            var t = new string('t', 32);
            var enc = new ASCIIEncoding();
            var bytes = enc.GetBytes(t);

            return bytes;
        }
    }
}