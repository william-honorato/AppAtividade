using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppAtividade
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CriarTela();
        }

        private void CriarTela()
        {
            var bot1 = new Button()
            {

                Text = "Internet",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            bot1.Clicked += ClickBotao;

            var bot2 = new Button
            {
                Text = "GPS",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            bot2.Clicked += ClickBotao;

            var bot3 = new Button
            {
                Text = "Email",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            bot3.Clicked += ClickBotao;

            var stk = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Padding = new Thickness(50),
                Margin = new Thickness(20),
                Children = { bot1, bot2, bot3 }
            };

            Content = new StackLayout
            {
                BackgroundColor = Color.Aqua,
                Children =
                {
                    stk
                }
            };
        }

        public async Task<string> Localizacao()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            string retorno = "Erro ao solicitar a localização";

            if (location != null)
                retorno = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";

            return retorno;
        }

        private string VericarAcessoInternet()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                return "On-Line";

            return "Off-Line";
        }

        private void MostrarMsg(string msg)
        {
            DisplayAlert("Mensagem", msg, "Ok");
        }

        private void ClickBotao(object sender, EventArgs e)
        {
            var btn = (sender as Button);

            try
            {
                if (btn.Text == "GPS")
                    MostrarMsg(Localizacao().Result);
                else if (btn.Text == "Email")
                    Navigation.PushAsync(new EmailPage());
                else
                    MostrarMsg(VericarAcessoInternet());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
