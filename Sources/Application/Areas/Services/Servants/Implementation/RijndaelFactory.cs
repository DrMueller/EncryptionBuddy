using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Services.Servants.Implementation
{
    public class RijndaelFactory : IRijndaelFactory
    {
        public async Task<Rijndael> CreateAsync()
        {
            using var rijandel = Rijndael.Create();
            rijandel.Key = await ProvideKeyAsync();
            rijandel.IV = await ProvideInitialVectorAsync();

            return rijandel;
        }

        private Task<byte[]> ProvideInitialVectorAsync()
        {
            var t = new string('t', 16);
            var enc = new ASCIIEncoding();
            var bytes = enc.GetBytes(t);
            return Task.FromResult(bytes);
        }

        private Task<byte[]> ProvideKeyAsync()
        {
            var t = new string('t', 32);
            var enc = new ASCIIEncoding();
            var bytes = enc.GetBytes(t);
            return Task.FromResult(bytes);
        }
    }
}