using HomeWork.Command;
using System.Windows;

namespace HomeWork
{
    public partial class MainWindow : Window
    {
        private readonly EncryptDecryptService _encryptDecryptService;

        public MainWindow()
        {
            InitializeComponent();

            var encryptViewModel = new EncryptViewModel();
            var decryptViewModel = new DecryptViewModel();

            _encryptDecryptService = new EncryptDecryptService(
                encryptViewModel,
                decryptViewModel,
                @"C:\Users\User\Desktop\thread.txt");

            DataContext = new
            {
                EncryptViewModel = encryptViewModel,
                DecryptViewModel = decryptViewModel,
                ResumeCommand = new ResumeCommand(_encryptDecryptService),
                PauseCommand = new PauseCommand(_encryptDecryptService),
                CancelCommand = new CancelCommand(_encryptDecryptService)
            };

            _encryptDecryptService.StartProcessing();
        }
    }




}
