using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork.Command
{
    public class CancelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly EncryptDecryptService _service;
        public CancelCommand(EncryptDecryptService service)
        {
            _service = service;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _service.CancelProcessing();
        }
    }
}
