﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Wb.EncryptionBuddy.Areas.Encryption.Domain.Services;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.ViewData;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.Views;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.ViewServices;

namespace Mmu.Wb.EncryptionBuddy.Areas.Encryption.WpfUI.Views.Main
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IFavoritesOverviewViewService _favoritesOverviewService;
        private readonly IServiceLocator _serviceLocator;
        private FavoriteOverviewEntryViewData _selectedFavoriteEntry;

        public MainWindow(
            IFavoritesOverviewViewService favoritesOverviewService,
            IEncryptionService encryptionService,
            IServiceLocator serviceLocator)
        {
            _favoritesOverviewService = favoritesOverviewService;
            _encryptionService = encryptionService;
            _serviceLocator = serviceLocator;
            DataContext = this;

            Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CloseCommand => new RelayCommand(Close);
        public ObservableCollection<FavoriteOverviewEntryViewData> Favorites { get; private set; }

        public FavoriteOverviewEntryViewData SelectedFavoriteEntry
        {
            get => _selectedFavoriteEntry;
            set
            {
                if (_selectedFavoriteEntry == value)
                {
                    return;
                }

                _selectedFavoriteEntry = value;
                OnPropertyChanged();

                TxbValue.Text = _selectedFavoriteEntry?.Base64Value ?? string.Empty;
                Dispatcher.Invoke(
                    async () =>
                    {
                        await ConvertAsync();
                    });
            }
        }

        private async void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            await ConvertAsync();
        }

        private async void BtnManageFavorites_Click(object sender, RoutedEventArgs e)
        {
            var favoritesOverviewWindow = _serviceLocator.GetService<FavoriteEntriesOverviewWindow>();
            if (favoritesOverviewWindow.ShowDialog() != true)
            {
                return;
            }

            await LoadOverviewAsync();
            SelectedFavoriteEntry = null;
        }

        private async Task ConvertAsync()
        {
            var newValue = await _encryptionService.ConvertAsync(TxbValue.Text);
            TxbNewValue.Text = newValue;

            Clipboard.SetText(newValue);
        }

        private async Task LoadOverviewAsync()
        {
            var entries = await _favoritesOverviewService.LoadAllEntriesAsync();
            Favorites = new ObservableCollection<FavoriteOverviewEntryViewData>(entries);
            OnPropertyChanged(nameof(Favorites));
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadOverviewAsync();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}