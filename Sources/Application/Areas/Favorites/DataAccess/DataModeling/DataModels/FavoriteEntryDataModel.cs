using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.DataAccess.DataModeling.DataModels
{
    public class FavoriteEntryDataModel : AggregateRootDataModel<string>
    {
        public string Base64Value { get; set; }
        public string Name { get; set; }
    }
}