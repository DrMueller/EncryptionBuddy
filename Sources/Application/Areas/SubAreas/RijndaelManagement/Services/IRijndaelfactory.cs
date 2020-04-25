using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.RijndaelManagement.Services
{
    public interface IRijndaelFactory
    {
        Task<System.Security.Cryptography.Rijndael> CreateAsync();
    }
}