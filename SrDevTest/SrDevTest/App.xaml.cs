using System;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using SrDevTest.Sql;
using SrDevTest.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SrDevTest
{
    public partial class App : Application
    {
        public IServiceProvider services { get; }
        public static SQLRepository dbContext;
        public new static App Current => (App)Application.Current;
        public App ()
        {
            services = configureService();
            dbContext = new SQLRepository();
            InitializeComponent();
            MainPage = new AppShell();

        }
        protected override async void OnStart ()
        {
         await dbContext.InitializeAsync();
        }
        protected override void OnSleep ()
        {
        }
        protected override void OnResume ()
        {
        }
        private static IServiceProvider configureService()
        {
            var services = new ServiceCollection();
            services.AddTransient<PageOneViewModel>();
            services.AddTransient<PageTwoViewModel>();
            services.AddTransient<PageThreeViewModel>();
            return services.BuildServiceProvider();
        }
    }
}

