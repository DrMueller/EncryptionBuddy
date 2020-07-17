using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Wb.EncryptionBuddy.Areas.Encryption.WpfUI.Views.Main;

namespace Mmu.Wb.EncryptionBuddy
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly, initializeAutoMapper: true);
            var container = ServiceProvisioningInitializer.CreateContainer(containerConfig);

            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");

            var window = container.GetInstance<MainWindow>();
            window.Icon = new BitmapImage(new Uri(iconPath));

            window.ShowDialog();
        }
    }
}