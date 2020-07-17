using System.Security.Cryptography;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services.Servants;

namespace Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services.Implementation
{
    [UsedImplicitly]
    public class RijndaelFactory : IRijndaelFactory
    {
        private readonly ISecretProvider _secretProvider;

        public RijndaelFactory(ISecretProvider secretProvider)
        {
            _secretProvider = secretProvider;
        }

        public async Task<Rijndael> CreateAsync()
        {
            var rijandel = Rijndael.Create();
            var secrets = await _secretProvider.ProvideSecretsAsync();

            rijandel.Key = secrets.Key;
            rijandel.IV = secrets.InitialVector;

            return rijandel;
        }
    }
}