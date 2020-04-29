using System.IO.Abstractions;
using JetBrains.Annotations;
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
        }
    }
}