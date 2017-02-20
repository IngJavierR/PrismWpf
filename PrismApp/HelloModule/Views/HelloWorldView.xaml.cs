using HelloModule.Events;
using HelloModule.ViewModels;
using Microsoft.Practices.Prism.Mvvm;

namespace HelloModule.Views
{
    /// <summary>
    /// Lógica de interacción para HelloWorldView.xaml
    /// </summary>
    public partial class HelloWorldView : IView
    {
        public HelloWorldView()
        {
            InitializeComponent();
            DataContext = new HelloViewModel(ApplicationService.Instance.EventAggregator);
        }
    }
}
