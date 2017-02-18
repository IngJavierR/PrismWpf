using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace HelloModule
{
    public class HelloWorldModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public HelloWorldModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.HelloWorldView));
            _regionManager.RegisterViewWithRegion("SecondRegion", typeof(Views.SecondView));
        }
    }
}
