using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Models;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Services
{
    public interface IFavoriteEntryRepository : IRepository<FavoriteEntry, string>
    {
    }
}