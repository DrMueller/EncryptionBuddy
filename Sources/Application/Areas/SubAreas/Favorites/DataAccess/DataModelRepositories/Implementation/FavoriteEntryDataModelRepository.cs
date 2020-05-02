using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModeling;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Implementation;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Servants;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModelRepositories.Implementation
{
    public class FavoriteEntryDataModelRepository : FileSystemDataModelRepository<FavoriteEntryDataModel>, IFavoriteEntryDataModelRepository
    {
        public FavoriteEntryDataModelRepository(IFileSystemProxy<FavoriteEntryDataModel> fileSystemProxy, IDataModelFileAdapter<FavoriteEntryDataModel> dataModelFileAdapter) : base(fileSystemProxy, dataModelFileAdapter)
        {
        }
    }
}