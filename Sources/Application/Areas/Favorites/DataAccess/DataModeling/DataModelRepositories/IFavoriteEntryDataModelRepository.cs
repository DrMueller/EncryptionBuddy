using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelRepositories
{
    public interface IFavoriteEntryDataModelRepository : IDataModelRepository<FavoriteEntryDataModel, string>
    {
    }
}