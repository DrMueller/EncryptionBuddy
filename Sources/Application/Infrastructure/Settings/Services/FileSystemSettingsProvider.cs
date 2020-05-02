using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;

namespace Mmu.EncryptionBuddy.Infrastructure.Settings.Services
{
    public class FileSystemSettingsProvider : IFileSystemSettingsProvider
    {
        public FileSystemSettings ProvideFileSystemSettings()
        {
            return new FileSystemSettings { DirectoryPath = @"Dropbox\Apps\EncryptionBuddy\CmbFavorites" };
        }
    }
}