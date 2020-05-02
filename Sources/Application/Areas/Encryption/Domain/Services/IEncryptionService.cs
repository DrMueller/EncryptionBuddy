using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Encryption.Domain.Services
{
    public interface IEncryptionService
    {
        Task<string> ConvertAsync(string value);
    }
}