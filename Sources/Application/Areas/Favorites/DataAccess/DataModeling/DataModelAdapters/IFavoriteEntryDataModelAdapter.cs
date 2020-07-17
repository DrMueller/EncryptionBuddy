using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Models;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelAdapters
{
    public interface IFavoriteEntryDataModelAdapter : IDataModelAdapter<FavoriteEntryDataModel, FavoriteEntry, string>
    {
    }
}