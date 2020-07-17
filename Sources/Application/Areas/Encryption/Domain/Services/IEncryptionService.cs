using System.Threading.Tasks;

namespace Mmu.Wb.EncryptionBuddy.Areas.Encryption.Domain.Services
{
    public interface IEncryptionService
    {
        Task<string> ConvertAsync(string value);
    }
}