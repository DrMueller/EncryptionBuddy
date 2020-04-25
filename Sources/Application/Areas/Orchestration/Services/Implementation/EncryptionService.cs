using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.SubAreas.RijndaelManagement.Services;

namespace Mmu.EncryptionBuddy.Areas.Orchestration.Services.Implementation
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IRijndaelFactory _rijndaelFactory;

        public EncryptionService(IRijndaelFactory rijndaelFactory)
        {
            _rijndaelFactory = rijndaelFactory;
        }

        // https://stackoverflow.com/questions/1629828/how-to-encrypt-a-string-in-net
        public async Task<string> DecryptAsync(string cipherText)
        {
            using var rijndaelCipher = await _rijndaelFactory.CreateAsync();
            await using var memoryStream = new MemoryStream();
            using var rijndaelDecryptor = rijndaelCipher.CreateDecryptor();

            var cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);
            var cipherBytes = Convert.FromBase64String(cipherText);
            cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

            cryptoStream.FlushFinalBlock();
            var plainBytes = memoryStream.ToArray();

            return Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
        }

        public async Task<string> EncryptAsync(string plainText)
        {
            using var rijndaelCipher = await _rijndaelFactory.CreateAsync();
            var rijndaelEncryptor = rijndaelCipher.CreateEncryptor();

            await using var memoryStream = new MemoryStream();
            await using var cryptoStream = new CryptoStream(memoryStream, rijndaelEncryptor, CryptoStreamMode.Write);

            var plainBytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherBytes = memoryStream.ToArray();
            var cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
            return cipherText;
        }
    }
}