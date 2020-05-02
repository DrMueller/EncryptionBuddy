using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;

namespace Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelRepositories
{
    public interface IFavoriteEntryDataModelRepository : IDataModelRepository<FavoriteEntryDataModel, string>
    {
    }
}