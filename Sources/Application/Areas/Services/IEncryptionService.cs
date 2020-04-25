using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Services
{
    public interface IEncryptionService
    {
        Task<string> DescryptAsync(string encryptedValue);

        Task<string> EncryptAsync(string value);
    }
}