﻿using ReactiveUI;
using ReactiveUI.XamForms;
using XamarinFormsReactiveUIDemo.Pages;
using XamarinFormsReactiveUIDemo.Services;
using XamarinFormsReactiveUIDemo.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsReactiveUIDemo
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            RegisterServices();
            RegisterViews();

            Router.Navigate.Execute(new CollectionViewModel());
        }

        public RoutingState Router { get; }

        private void RegisterServices()
        {
            Locator.CurrentMutable.Register(() => new StaticContactsService(), typeof(IContactsService));
        }

        private void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new FirstPage(), typeof(IViewFor<FirstViewModel>));
            Locator.CurrentMutable.Register(() => new SecondPage(), typeof(IViewFor<SecondViewModel>));
            Locator.CurrentMutable.Register(() => new CollectionPage(), typeof(IViewFor<CollectionViewModel>));
            //Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
