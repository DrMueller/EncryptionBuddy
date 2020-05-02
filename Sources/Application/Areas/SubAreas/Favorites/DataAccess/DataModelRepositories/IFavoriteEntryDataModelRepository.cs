using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModeling;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModelRepositories
{
    public interface IFavoriteEntryDataModelRepository : IDataModelRepository<FavoriteEntryDataModel, string>
    {
    }
}