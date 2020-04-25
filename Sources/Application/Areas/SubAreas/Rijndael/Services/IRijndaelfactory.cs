using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Services
{
    public interface IRijndaelFactory
    {
        Task<System.Security.Cryptography.Rijndael> CreateAsync();
    }
}