using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomeWork
{
    public class DecryptViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _decryptedLines;
        public ObservableCollection<string> DecryptedLines
        {
            get => _decryptedLines;
            set
            {
                _decryptedLines = value;
                OnPropertyChanged(nameof(DecryptedLines));
            }
        }

        private ObservableCollection<string> _processedLines;
        public ObservableCollection<string> ProcessedLines
        {
            get => _processedLines;
            set
            {
                _processedLines = value;
                OnPropertyChanged(nameof(ProcessedLines));
            }
        }

        public DecryptViewModel()
        {
            DecryptedLines = new ObservableCollection<string>();
            ProcessedLines = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
