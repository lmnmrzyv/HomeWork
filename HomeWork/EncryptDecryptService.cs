using HomeWork;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;

public class EncryptDecryptService
{
    private readonly EncryptViewModel _encryptViewModel;
    private readonly DecryptViewModel _decryptViewModel;
    private readonly string _filePath;
    private Thread _readThread;
    private Thread _encryptThread;
    private bool _isReadingComplete = false;

    public EncryptDecryptService(EncryptViewModel encryptViewModel, DecryptViewModel decryptViewModel, string filePath)
    {
        _encryptViewModel = encryptViewModel;
        _decryptViewModel = decryptViewModel;
        _filePath = filePath;
    }

    public void StartProcessing()
    {
        _readThread = new Thread(ReadAndStoreLines);
        _encryptThread = new Thread(EncryptLines);

        _readThread.Start();
        _encryptThread.Start();
    }

    private void ReadAndStoreLines()
    {
        while (true)
        {
            if (File.Exists(_filePath))
            {
                using (var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(fileStream))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                _decryptViewModel.ProcessedLines.Add(line);
                            });

                            Thread.Sleep(100); // Simülasyon için gecikme
                        }
                    }
                }
            }
        }
    }

    private void EncryptLines()
    {
        while (true)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_decryptViewModel.ProcessedLines.Count > 0)
                {
                    var lineToEncrypt = _decryptViewModel.ProcessedLines[0];

                    _decryptViewModel.DecryptedLines.Add(lineToEncrypt);
                    _decryptViewModel.ProcessedLines.RemoveAt(0);


                    if (lineToEncrypt != null)
                    {
                        string encryptedLine = AesEncryption.Encrypt(lineToEncrypt);
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            _encryptViewModel.EncryptedLines.Add(encryptedLine);
                        });
                    }

                }
            });

            if (_isReadingComplete)
                break;

            Thread.Sleep(500);
        }
    }


    public void PauseProcessing()
    {
        var threadState = _encryptThread.ThreadState;

        _encryptThread.Suspend();
    }

    public void ResumeProcessing()
    {
        var threadState = _encryptThread.ThreadState;

        _encryptThread.Resume();
    }

    public void CancelProcessing()
    {
        var threadState = _encryptThread.ThreadState;

        _encryptThread.Abort();
    }
}
