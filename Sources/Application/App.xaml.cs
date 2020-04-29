using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Mmu.EncryptionBuddy.Areas.Views;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using StructureMap;

namespace Mmu.EncryptionBuddy
{
    public partial class App
    {
        private IContainer _container;
        private bool _isWindowOpen;

        // https://stackoverflow.com/questions/1472633/wpf-application-that-only-has-a-tray-icon
        // C:\Users\mlm\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            _container = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");

            var notifyIcon = new NotifyIcon();
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            notifyIcon.Text = "Encryption Buddy";
            notifyIcon.Icon = new Icon(iconPath);
            notifyIcon.Visible = true;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (_isWindowOpen)
            {
                return;
            }

            _isWindowOpen = true;
            var window = _container.GetInstance<MainWindow>();
            window.Closed += Window_Closed;
            window.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _isWindowOpen = false;
        }
    }
}