using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Orchestration.Services
{
    public interface IEncryptionService
    {
        Task<string> ConvertAsync(string value);
    }
}