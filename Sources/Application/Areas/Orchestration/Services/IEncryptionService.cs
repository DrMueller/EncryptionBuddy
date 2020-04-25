using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Orchestration.Services
{
    public interface IEncryptionService
    {
        Task<string> DescryptAsync(string cipherText);

        Task<string> EncryptAsync(string value);
    }
}