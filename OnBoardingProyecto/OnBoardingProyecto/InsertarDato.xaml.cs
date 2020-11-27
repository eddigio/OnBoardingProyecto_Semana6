using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace OnBoardingProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarDato : ContentPage
    {
        public InsertarDato()
        {
            InitializeComponent();
        }

        private async  void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo",txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
               // parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.27/onboarding/post.php","POST",parametros);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error:" + ex.Message, "OK");

            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            //espera
            await Navigation.PushAsync(new MainPage());
        }
    }
}
