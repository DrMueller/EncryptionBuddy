using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.Domain.Models
{
    public class FavoriteEntry : AggregateRoot<string>
    {
        public FavoriteEntry(string name, string base64Value, string id)
            : base(id)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => base64Value);

            Name = name;
            Base64Value = base64Value;
        }

        public string Base64Value { get; }
        public string Name { get; }
    }
}