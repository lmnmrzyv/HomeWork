using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class EncryptViewModel : INotifyPropertyChanged
{
    private ObservableCollection<string> _encryptedLines;
    public ObservableCollection<string> EncryptedLines
    {
        get => _encryptedLines;
        set
        {
            _encryptedLines = value;
            OnPropertyChanged(nameof(EncryptedLines));
        }
    }

   

    public EncryptViewModel()
    {
        EncryptedLines = new ObservableCollection<string>();
       
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
