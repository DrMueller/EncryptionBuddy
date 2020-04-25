using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Services
{
    public interface IEncryptionService
    {
        Task<string> DescryptAsync(string cipherText);

        Task<string> EncryptAsync(string value);
    }
}