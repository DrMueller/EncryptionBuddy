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
        public async Task<string> DescryptAsync(string encryptedValue)
        {
            using var rijandel = await _rijndaelFactory.CreateAsync();
            await using var memoryStream = new MemoryStream();
            var rijndaelDecryptor = rijandel.CreateDecryptor();
            
            await using var cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);
            var cipherBytes = Convert.FromBase64String(encryptedValue);
            
            cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
            cryptoStream.FlushFinalBlock();
            
            var plainBytes = memoryStream.ToArray();
            return Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
        }

        public async Task<string> EncryptAsync(string value)
        {
            using var rijandel = await _rijndaelFactory.CreateAsync();
            var encryptor = rijandel.CreateEncryptor(rijandel.Key, rijandel.IV);
            
            await using var memoryStream = new MemoryStream();
            await using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            var plainBytes = Encoding.ASCII.GetBytes(value);
            
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();
            
            var cipherBytes = memoryStream.ToArray();
            var cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            return cipherText;
        }

    }
}