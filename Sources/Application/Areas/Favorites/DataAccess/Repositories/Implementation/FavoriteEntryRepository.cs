using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelAdapters;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelRepositories;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Models;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Services;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.Repositories.Implementation
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