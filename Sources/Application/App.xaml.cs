using System.Windows;
using Mmu.EncryptionBuddy.Areas.Views;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.EncryptionBuddy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            var config = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            var window = config.GetInstance<MainWindow>();

            window.ShowDialog();
        }
    }
}