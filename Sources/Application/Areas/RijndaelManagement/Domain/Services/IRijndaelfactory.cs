using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Mmu.Wb.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services
{
    public interface IRijndaelFactory
    {
        Task<Rijndael> CreateAsync();
    }
}