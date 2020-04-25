using System.Windows;
using Mmu.EncryptionBuddy.Areas.Orchestration.Services;

namespace Mmu.EncryptionBuddy.Areas.Views
{
    public partial class MainWindow
    {
        private readonly IEncryptionService _encryptionService;

        public MainWindow(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
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