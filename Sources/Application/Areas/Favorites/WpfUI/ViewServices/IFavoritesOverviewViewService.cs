using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.Favorites.WpfUI.ViewData;

namespace Mmu.EncryptionBuddy.Areas.Favorites.WpfUI.ViewServices
{
    public interface IFavoritesOverviewViewService
    {
        Task<IReadOnlyCollection<FavoriteOverviewEntryViewData>> LoadAllEntriesAsync();

        Task SaveEntriesAsync(IReadOnlyCollection<FavoriteOverviewEntryViewData> entries);
    }
}