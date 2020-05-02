using AutoMapper;
using Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels;
using Mmu.EncryptionBuddy.Areas.Favorites.Domain.Models;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;

namespace Mmu.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModelAdapters.Implementation
{
    public class FavoriteEntryDataModelAdapter : DataModelAdapterBase<FavoriteEntryDataModel, FavoriteEntry, string>, IFavoriteEntryDataModelAdapter
    {
        public FavoriteEntryDataModelAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override FavoriteEntry Adapt(FavoriteEntryDataModel dataModel)
        {
            return new FavoriteEntry(
                dataModel.Name,
                dataModel.Base64Value,
                dataModel.Id);
        }
    }
}