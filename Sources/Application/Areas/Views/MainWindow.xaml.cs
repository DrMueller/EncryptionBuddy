using System.Windows;
using Mmu.EncryptionBuddy.Areas.Orchestration.Services;

namespace Mmu.EncryptionBuddy.Areas.Views
{
    public partial class MainWindow : Window
    {
        private readonly IEncryptionService _encryptionService;

        public MainWindow(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
            InitializeComponent();
        }

        private async void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            TxbNewValue.Text = await _encryptionService.DescryptAsync(TxbValue.Text);
        }

        private async void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            TxbNewValue.Text = await _encryptionService.EncryptAsync(TxbValue.Text);
        }
    }
}