using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloModule.ViewModels
{
    public class SecondViewModel : BindableBase
    {
        #region Properties

        private string _buttonMsg;
        public string ButtonMsg
        {
            get { return _buttonMsg; }
            set
            {
                if (_buttonMsg == value) return;
                SetProperty(ref _buttonMsg, value);
                OnPropertyChanged(() => ButtonMsg);
            }
        }
        #endregion

        #region Constructor
        public SecondViewModel()
        {
            SayHello = new DelegateCommand<object>(OnSubmit, CanSubmit);
            ButtonMsg = "Presioname!";
        }
        #endregion

        #region ICommand
        public ICommand SayHello { get; private set; }
        #endregion

        #region DelegateCommands
        private void OnSubmit(object arg)
        {
            MessageBox.Show("Hola!");
            ButtonMsg = "Otra vez!";
        }
        private static bool CanSubmit(object arg) { return true; }

        #endregion
    }
}
