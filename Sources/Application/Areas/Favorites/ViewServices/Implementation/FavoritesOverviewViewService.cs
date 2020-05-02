using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.EncryptionBuddy.Areas.Favorites.ViewData;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Models;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Services;

namespace Mmu.EncryptionBuddy.Areas.Favorites.ViewServices.Implementation
{
    public class FavoritesOverviewViewService : IFavoritesOverviewViewService
    {
        private readonly IFavoriteEntryRepository _favoriteEntrRepo;

        public FavoritesOverviewViewService(IFavoriteEntryRepository favoriteEntrRepo)
        {
            _favoriteEntrRepo = favoriteEntrRepo;
        }

        public async Task<IReadOnlyCollection<FavoriteOverviewEntryViewData>> LoadAllEntriesAsync()
        {
            var allEntries = await _favoriteEntrRepo.LoadAllAsync();
            var result = allEntries
                .Select(fav => new FavoriteOverviewEntryViewData { Base64Value = fav.Base64Value, Id = fav.Id, Name = fav.Name })
                .OrderBy(fav => fav.Name)
                .ToList();

            return result;
        }

        public async Task SaveEntriesAsync(IReadOnlyCollection<FavoriteOverviewEntryViewData> entries)
        {
            await DeleteEntriesAsync(entries);
            await UpsertEntriesAsync(entries);
        }

        private async Task DeleteEntriesAsync(IEnumerable<FavoriteOverviewEntryViewData> entries)
        {
            var allEntries = await _favoriteEntrRepo.LoadAllAsync();

            var existingIds = entries.Select(entry => entry.Id);
            var allIds = allEntries.Select(entry => entry.Id);
            var idsToDelete = allIds.Except(existingIds);
            var deleteTasks = idsToDelete.Select(id => _favoriteEntrRepo.DeleteAsync(id));

            await Task.WhenAll(deleteTasks);
        }

        private async Task UpsertEntriesAsync(IEnumerable<FavoriteOverviewEntryViewData> entries)
        {
            var favorites = entries.Select(entry => new FavoriteEntry(entry.Name, entry.Base64Value, entry.Id)).ToList();
            var saveTasks = favorites.Select(fav => _favoriteEntrRepo.SaveAsync(fav));
            await Task.WhenAll(saveTasks);
        }
    }
}