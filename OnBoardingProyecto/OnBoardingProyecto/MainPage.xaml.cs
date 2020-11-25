using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnBoardingProyecto
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.27/onboarding/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OnBoardingProyecto.Ws.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get(){
            try
            {
                var content = await client.GetStringAsync(Url);
                List<OnBoardingProyecto.Ws.Datos> posts = JsonConvert.DeserializeObject<List<OnBoardingProyecto.Ws.Datos>>(content);
                _post = new ObservableCollection<OnBoardingProyecto.Ws.Datos>(posts);
                MyListView.ItemsSource = _post;
            }
            catch (Exception ex){
                DisplayAlert("Error", "ERROR"+ex.Message,"OK");
            }
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarDato());

        }
        private void btnPost_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Delete());
        }


    }
}
