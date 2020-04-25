using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Mmu.EncryptionBuddy.Areas.Services.Servants
{
    public interface IRijndaelFactory
    {
        Task<Rijndael> CreateAsync();
    }
}