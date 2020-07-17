using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.ViewData;
using Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.ViewServices;

namespace Mmu.Wb.EncryptionBuddy.Areas.Favorites.WpfUI.Views
{
    public partial class FavoriteEntriesOverviewWindow : Window, INotifyPropertyChanged
    {
        private readonly IFavoritesOverviewViewService _overviewService;
        private FavoriteOverviewEntryViewData _selectedEntry;

        public FavoriteEntriesOverviewWindow(IFavoritesOverviewViewService overviewService)
        {
            _overviewService = overviewService;

            Loaded += FavoriteEntriesOverviewWindow_Loaded;
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool CanDeleteEntry => SelectedEntry != null;
        public ObservableCollection<FavoriteOverviewEntryViewData> Favorites { get; private set; }

        public FavoriteOverviewEntryViewData SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                if (_selectedEntry == value)
                {
                    return;
                }

                _selectedEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanDeleteEntry));
            }
        }

        private void AddFavoriteEntry_Click(object sender, RoutedEventArgs e)
        {
            Favorites.Add(new FavoriteOverviewEntryViewData());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void DeleteSelectedEntry_Click(object sender, RoutedEventArgs e)
        {
            Favorites.Remove(SelectedEntry);
            SelectedEntry = null;
        }

        private async void FavoriteEntriesOverviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var entries = await _overviewService.LoadAllEntriesAsync();

            Favorites = new ObservableCollection<FavoriteOverviewEntryViewData>(entries);
            OnPropertyChanged(nameof(Favorites));
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void SaveFavoriteEntries_Click(object sender, RoutedEventArgs e)
        {
            await _overviewService.SaveEntriesAsync(Favorites);

            DialogResult = true;
            Close();
        }
    }
}