using Mmu.EncryptionBuddy.Areas.Favorites.Domain.Models;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;

namespace Mmu.EncryptionBuddy.Areas.Favorites.Domain.Services
{
    public interface IFavoriteEntryRepository : IRepository<FavoriteEntry, string>
    {
    }
}