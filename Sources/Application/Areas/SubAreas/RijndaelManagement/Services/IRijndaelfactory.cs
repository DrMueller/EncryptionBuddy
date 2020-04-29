using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.RijndaelManagement.Services
{
    public interface IRijndaelFactory
    {
        Task<Rijndael> CreateAsync();
    }
}