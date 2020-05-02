using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModeling;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModelRepositories;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModelRepositories.Adapters;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Models;
using Mmu.Mlh.DataAccess.Areas.Repositories;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Services.Implementation
{
    public class FavoriteEntryRepository : RepositoryBase<FavoriteEntry, FavoriteEntryDataModel, string>, IFavoriteEntryRepository
    {
        public FavoriteEntryRepository(
            IFavoriteEntryDataModelRepository dataModelRepository,
            IFavoriteEntryDataModelAdapter dataModelAdapter)
            : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}