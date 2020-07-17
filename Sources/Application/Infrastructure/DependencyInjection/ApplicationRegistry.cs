using System.IO.Abstractions;
using JetBrains.Annotations;
using Lamar;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Wb.EncryptionBuddy.Infrastructure.Settings.Services;

namespace Mmu.Wb.EncryptionBuddy.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class ApplicationRegistry : ServiceRegistry
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