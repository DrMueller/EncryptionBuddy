namespace Mmu.EncryptionBuddy.Areas.Favorites.ViewData
{
    public class FavoriteOverviewEntryViewData
    {
        public string Base64Value { get; set; }
        public string Id { get; set; }

        public bool IsNew => string.IsNullOrEmpty(Id);
        public string Name { get; set; }
    }
}