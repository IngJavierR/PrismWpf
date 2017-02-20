using System.Windows;
using System.Windows.Input;
using HelloModule.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace HelloModule.ViewModels
{
    public class SecondViewModel : BindableBase
    {
        #region Events
        protected readonly IEventAggregator EventAggregator;
        #endregion
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
        public SecondViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            SayHello = new DelegateCommand<object>(OnSubmit, CanSubmit);
            ButtonMsg = "Presioname!";
            eventAggregator.GetEvent<HelloEvent>().Subscribe(HelloEventChange);
        }

        private static void HelloEventChange(object obj)
        {
            MessageBox.Show("Clicked in hello view");
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
