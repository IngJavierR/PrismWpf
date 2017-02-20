using HelloModule.Events;
using HelloModule.ViewModels;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloModule.Views
{
    /// <summary>
    /// Lógica de interacción para SecondView.xaml
    /// </summary>
    public partial class SecondView : IView
    {
        public SecondView()
        {
            InitializeComponent();
            DataContext = new SecondViewModel(ApplicationService.Instance.EventAggregator);
        }
    }
}
