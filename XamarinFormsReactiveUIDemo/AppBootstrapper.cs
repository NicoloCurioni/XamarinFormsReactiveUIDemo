using System;
using XamarinFormsReactiveUIDemo.Services;

namespace XamarinFormsReactiveUIDemo
{
    public class AppBootstrapper
    {
        public AppBootstrapper()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Splat.Locator.CurrentMutable.Register(() => new StaticContactsService(), typeof(IContactsService));
        }
    }
}
