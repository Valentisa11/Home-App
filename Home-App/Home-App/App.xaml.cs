using Home_App.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Home_App
{
    public partial class App : Application
    {
        public App()
        {
            // инициализация интерфейса
            InitializeComponent();
            // Инициализация главного экрана
            MainPage = new LoginPage(); //  DevicesPage(); new NewDevicePage(); new PaddingPage(); new LoginPage();  new LoadingPage();  new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}