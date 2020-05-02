using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.Favorites.ViewData;

namespace Mmu.EncryptionBuddy.Areas.Favorites.ViewServices
{
    public interface IFavoritesOverviewViewService
    {
        Task<IReadOnlyCollection<FavoriteOverviewEntryViewData>> LoadAllEntriesAsync();

        Task SaveEntriesAsync(IReadOnlyCollection<FavoriteOverviewEntryViewData> entries);
    }
}