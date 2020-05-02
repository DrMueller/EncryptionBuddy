using System.IO.Abstractions;
using JetBrains.Annotations;
using Mmu.EncryptionBuddy.Infrastructure.Settings.Services;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using StructureMap;

namespace Mmu.EncryptionBuddy.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
            For<IFileSystemSettingsProvider>().Use<FileSystemSettingsProvider>().Singleton();
        }
    }
}