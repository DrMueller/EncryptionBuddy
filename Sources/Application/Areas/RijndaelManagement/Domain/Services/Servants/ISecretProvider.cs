using System.Threading.Tasks;
using Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Models;

namespace Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services.Servants
{
    public interface ISecretProvider
    {
        Task<RijndaelSecrets> ProvideSecretsAsync();
    }
}