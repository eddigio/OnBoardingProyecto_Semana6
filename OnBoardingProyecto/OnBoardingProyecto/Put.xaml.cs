using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;

namespace OnBoardingProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {
        public Put()
        {
            InitializeComponent();
        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var url = "http://192.168.100.27/onboarding/post.php";
                string sData = Newtonsoft.Json.JsonConvert.SerializeObject(txtCodigo);
                HttpClient cliente = new HttpClient();
                HttpContent content = new System.Net.Http.StringContent(sData, System.Text.Encoding.UTF8, "application/json");
                var httpResponseMessage = cliente.PutAsync(url, content);
                if (httpResponseMessage != null)
                {
                    await DisplayAlert("alerta", "Modifico correctamente", "ok");
                }
                else
                {
                    await DisplayAlert("alerta", "ERROR", "ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error:" + ex.Message, "OK");

            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}