using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services;

namespace Mmu.Wb.EncryptionBuddy.Areas.Encryption.Domain.Services.Implementation
{
    [UsedImplicitly]
    public class EncryptionService : IEncryptionService
    {
        private readonly IRijndaelFactory _rijndaelFactory;

        public EncryptionService(IRijndaelFactory rijndaelFactory)
        {
            _rijndaelFactory = rijndaelFactory;
        }

        public async Task<string> ConvertAsync(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (IsBase64(value))
            {
                return await DecryptAsync(value);
            }

            return await EncryptAsync(value);
        }

        // https://stackoverflow.com/questions/6309379/how-to-check-for-a-valid-base64-encoded-string
        private static bool IsBase64(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                value.Length % 4 != 0 ||
                value.Contains(" ", StringComparison.OrdinalIgnoreCase) ||
                value.Contains("\t", StringComparison.OrdinalIgnoreCase) ||
                value.Contains("\r", StringComparison.OrdinalIgnoreCase) ||
                value.Contains("\n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var regex = new Regex(@"^[a-zA-Z0-9\+/]*={2}$");
            if (!regex.IsMatch(value))
            {
                return false;
            }

            var buffer = new Span<byte>(new byte[value.Length]);
            return Convert.TryFromBase64String(value, buffer, out _);
        }

        // https://stackoverflow.com/questions/1629828/how-to-encrypt-a-string-in-net
        private async Task<string> DecryptAsync(string cipherText)
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

        private async Task<string> EncryptAsync(string plainText)
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