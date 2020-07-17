using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Models;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Services
{
    public interface IFavoriteEntryRepository : IRepository<FavoriteEntry, string>
    {
    }
}