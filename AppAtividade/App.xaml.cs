using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAtividade
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage() { Title="Teste de Hardware" });
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
