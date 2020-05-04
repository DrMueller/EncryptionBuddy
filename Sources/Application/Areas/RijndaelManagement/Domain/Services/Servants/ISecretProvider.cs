using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.RijndaelManagement.Domain.Models;

namespace Mmu.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services.Servants
{
    public interface ISecretProvider
    {
        Task<RijndaelSecrets> ProvideSecretsAsync();
    }
}