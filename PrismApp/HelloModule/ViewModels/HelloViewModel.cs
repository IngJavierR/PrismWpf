using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloModule.ViewModels
{
    public class HelloViewModel : BindableBase
    {
        #region Properties

        private string _buttonMsg;
        public string ButtonMsg
        {
            get { return _buttonMsg; }
            set {
                if (_buttonMsg == value) return;
                SetProperty(ref _buttonMsg, value);
                OnPropertyChanged(() => ButtonMsg);
            }
        }
        #endregion

        #region Constructor
        public HelloViewModel()
        {
            SayHello = new DelegateCommand<object>(OnSubmit, CanSubmit);
            ButtonMsg = "ClickMe!";
        }
        #endregion

        #region ICommand
        private ICommand _takePicture;
        public ICommand TakePicture
        {
            get { return _takePicture ?? (_takePicture = new DelegateCommand(TakePictureAction, () => true)); }
        }
        public ICommand SayHello { get; private set; }
        #endregion

        #region DelegateCommands
        private void OnSubmit(object arg)
        {
            MessageBox.Show("Hi!");
            ButtonMsg = "Again!";
        }
        private static bool CanSubmit(object arg) { return true; }

        private void TakePictureAction()
        {
            MessageBox.Show("Smile!");
            ButtonMsg = "Taked!";
        }

        #endregion
    }
}
