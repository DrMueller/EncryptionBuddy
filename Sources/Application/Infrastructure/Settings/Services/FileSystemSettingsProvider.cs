using System;
using System.IO.Abstractions;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;

namespace Mmu.Wb.EncryptionBuddy.Infrastructure.Settings.Services
{
    public class FileSystemSettingsProvider : IFileSystemSettingsProvider
    {
        private readonly IDropboxLocator _dropboxLocator;
        private readonly IFileSystem _fileSystem;

        public FileSystemSettingsProvider(IDropboxLocator dropboxLocator, IFileSystem fileSystem)
        {
            _dropboxLocator = dropboxLocator;
            _fileSystem = fileSystem;
        }

        public FileSystemSettings ProvideFileSystemSettings()
        {
            var dropboxPath = _dropboxLocator
                .LocateDropboxPath()
                .Reduce(() => throw new Exception("Could not locate Dropbox path."));

            var directoryPath = _fileSystem.Path.Combine(dropboxPath, @"Apps\EncryptionBuddy\CmbFavorites");

            return new FileSystemSettings { DirectoryPath = directoryPath };
        }
    }
}