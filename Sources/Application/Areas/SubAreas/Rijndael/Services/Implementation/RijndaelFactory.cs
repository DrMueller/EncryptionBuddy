using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Services.Servants;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Services.Implementation
{
    public class RijndaelFactory : IRijndaelFactory
    {
        private readonly ISecretProvider _secretProvider;

        public RijndaelFactory(ISecretProvider secretProvider)
        {
            _secretProvider = secretProvider;
        }

        public async Task<System.Security.Cryptography.Rijndael> CreateAsync()
        {
            var rijandel = System.Security.Cryptography.Rijndael.Create();
            var secrets = await _secretProvider.ProvideSecretsAsync();

            rijandel.Key = secrets.Key;
            rijandel.IV = secrets.InitialVector;

            return rijandel;
        }
    }
}