using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAtividade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            InitializeComponent();
        }

        public static async Task EnviarEmail(string subject, string body, List<string> recipients)
        {
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = recipients,
                Attachments = null,
                //Cc = ccRecipients,
                //Bcc = bccRecipients
            };
            await Email.ComposeAsync(message);
        }

        private void btnEnviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var listaEmail = new List<string>();
                listaEmail.Add(txtEndEmail.Text.Trim());

                var resposta = EnviarEmail(
                                            txtAssunto.Text.Trim(),
                                            txtMensagem.Text.Trim(),
                                            listaEmail
                                          );
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}