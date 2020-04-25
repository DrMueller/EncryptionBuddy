using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Mmu.EncryptionBuddy.Areas.Views;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.EncryptionBuddy
{
    public partial class App
    {
        // https://stackoverflow.com/questions/1472633/wpf-application-that-only-has-a-tray-icon
        // C:\Users\mlm\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
        protected override void OnStartup(StartupEventArgs e)
        {
            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");

            var notifyIcon = new NotifyIcon();
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            notifyIcon.Text = "Encryption Buddy";
            notifyIcon.Icon = new Icon(iconPath);
            notifyIcon.Visible = true;
        }

        private static void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            var config = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            var window = config.GetInstance<MainWindow>();
            window.ShowDialog();
        }
    }
}