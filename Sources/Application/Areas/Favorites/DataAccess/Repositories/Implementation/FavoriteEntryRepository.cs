using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelAdapters;
using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelRepositories;
using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.EncryptionBuddy.Areas.Favorites.Domain.Models;
using Mmu.EncryptionBuddy.Areas.Favorites.Domain.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;

namespace Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.Repositories.Implementation
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