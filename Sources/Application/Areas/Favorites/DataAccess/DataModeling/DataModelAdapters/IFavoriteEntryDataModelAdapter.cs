using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.EncryptionBuddy.Areas.Favorites.Domain.Models;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;

namespace Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelAdapters
{
    public interface IFavoriteEntryDataModelAdapter : IDataModelAdapter<FavoriteEntryDataModel, FavoriteEntry, string>
    {
    }
}