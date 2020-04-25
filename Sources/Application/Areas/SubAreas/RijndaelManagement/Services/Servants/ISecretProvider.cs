using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.SubAreas.RijndaelManagement.Models;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.RijndaelManagement.Services.Servants
{
    public interface ISecretProvider
    {
        Task<RijndaelSecrets> ProvideSecretsAsync();
    }
}