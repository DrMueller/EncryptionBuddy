using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Implementation;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Servants;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelRepositories.Implementation
{
    public class FavoriteEntryDataModelRepository : FileSystemDataModelRepository<FavoriteEntryDataModel>, IFavoriteEntryDataModelRepository
    {
        public FavoriteEntryDataModelRepository(IFileSystemProxy<FavoriteEntryDataModel> fileSystemProxy, IDataModelFileAdapter<FavoriteEntryDataModel> dataModelFileAdapter) : base(fileSystemProxy, dataModelFileAdapter)
        {
        }
    }
}