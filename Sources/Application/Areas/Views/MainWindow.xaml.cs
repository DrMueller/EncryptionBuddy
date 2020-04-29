using System.Windows;
using System.Windows.Input;
using Mmu.EncryptionBuddy.Areas.Orchestration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;

namespace Mmu.EncryptionBuddy.Areas.Views
{
    public partial class MainWindow
    {
        private readonly IEncryptionService _encryptionService;
        public ICommand CloseCommand => new RelayCommand(Close);

        public MainWindow(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
            DataContext = this;
            InitializeComponent();
        }

        private async void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var decyptedValue = await _encryptionService.DecryptAsync(TxbValue.Text);
            TxbNewValue.Text = decyptedValue;

            Clipboard.SetText(decyptedValue);
        }

        private async void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var encryptedValue = await _encryptionService.EncryptAsync(TxbValue.Text);
            TxbNewValue.Text = encryptedValue;

            Clipboard.SetText(encryptedValue);
        }
    }
}