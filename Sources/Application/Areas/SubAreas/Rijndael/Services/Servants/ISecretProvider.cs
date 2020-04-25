using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Models;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Services.Servants
{
    public interface ISecretProvider
    {
        Task<RijndaelSecrets> ProvideSecretsAsync();
    }
}