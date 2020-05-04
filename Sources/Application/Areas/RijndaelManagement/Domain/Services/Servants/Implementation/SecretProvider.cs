using System;
using System.IO.Abstractions;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.EncryptionBuddy.Areas.RijndaelManagement.Domain.Models;

namespace Mmu.EncryptionBuddy.Areas.RijndaelManagement.Domain.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class SecretProvider : ISecretProvider
    {
        private readonly IFileSystem _fileSystem;

        public SecretProvider(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<RijndaelSecrets> ProvideSecretsAsync()
        {
            var secretPath = GetSecretDropboxPath();
            var secretLines = await _fileSystem.File.ReadAllLinesAsync(secretPath);

            var initialVector = Encoding.ASCII.GetBytes(secretLines[0]);
            var key = Encoding.ASCII.GetBytes(secretLines[1]);

            return new RijndaelSecrets(initialVector, key);
        }

        private string GetSecretDropboxPath()
        {
            const string DropboxInfoPath = @"Dropbox\info.json";
            var jsonPath = _fileSystem.Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), DropboxInfoPath);

            if (!_fileSystem.File.Exists(jsonPath))
            {
                jsonPath = _fileSystem.Path.Combine(Environment.GetEnvironmentVariable("AppData"), DropboxInfoPath);
            }

            var dropboxPath = _fileSystem.File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\", StringComparison.OrdinalIgnoreCase);
            var completePath = _fileSystem.Path.Combine(dropboxPath, @"Apps\EncryptionBuddy\Secrets.txt");
            return completePath;
        }
    }
}