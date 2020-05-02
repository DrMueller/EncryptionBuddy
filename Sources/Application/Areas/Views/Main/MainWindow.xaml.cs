using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Mmu.EncryptionBuddy.Areas.Orchestration.Services;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Models;
using Mmu.EncryptionBuddy.Areas.SubAreas.Favorites.Services;
using Mmu.EncryptionBuddy.Areas.Views.FavoriteEntriesOverview;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;

namespace Mmu.EncryptionBuddy.Areas.Views.Main
{
    public partial class MainWindow
    {
        private readonly IFavoriteEntryRepository _favoriteEntryRepo;
        private readonly IEncryptionService _encryptionService;
        private readonly IServiceLocator _serviceLocator;
        public ICommand CloseCommand => new RelayCommand(Close);

        public ObservableCollection<FavoriteEntry> Favorites { get; private set; }

        public MainWindow(
            IFavoriteEntryRepository favoriteEntryRepo,
            IEncryptionService encryptionService,
            IServiceLocator serviceLocator)
        {
            _favoriteEntryRepo = favoriteEntryRepo;
            _encryptionService = encryptionService;
            _serviceLocator = serviceLocator;
            DataContext = this;

            this.Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var entries = await _favoriteEntryRepo.LoadAllAsync();
            Favorites = new ObservableCollection<FavoriteEntry>(entries);
        }

        private async void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            var newValue = await _encryptionService.ConvertAsync(TxbValue.Text);
            TxbNewValue.Text = newValue;

            Clipboard.SetText(newValue);
        }

        private void BtnManageFavorites_Click(object sender, RoutedEventArgs e)
        {
            var favoritesOverviewWindow = _serviceLocator.GetService<FavoriteEntriesOverviewWindow>();
            favoritesOverviewWindow.ShowDialog();
        }
    }
}