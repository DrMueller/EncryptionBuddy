using System;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.DataAccess.DataModeling
{
    public class FavoriteEntryDataModel : AggregateRootDataModel<string>
    {
        public string Base64Value { get; set; }
        public string Name { get; set; }
    }
}