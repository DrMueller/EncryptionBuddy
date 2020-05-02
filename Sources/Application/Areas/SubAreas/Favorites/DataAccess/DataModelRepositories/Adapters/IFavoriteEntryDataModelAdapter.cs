using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModeling;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Models;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModelRepositories.Adapters
{
    public interface IFavoriteEntryDataModelAdapter : IDataModelAdapter<FavoriteEntryDataModel, FavoriteEntry, string>
    {
    }
}