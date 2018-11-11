using Deputados.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Deputados
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesDeputado : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        Deputado deputado = new Deputado();

        public DetalhesDeputado()
        {
            InitializeComponent();
        }

        public DetalhesDeputado(Int32 idDep)
        {
            InitializeComponent();

            CarregaDetalhesDeputado(idDep);
        }

        async void CarregaDetalhesDeputado(Int32 idDep)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    var uri = "http://meucongressonacional.com/api/001/deputado/" + idDep;
                    var result = await client.GetStringAsync(uri);
                    deputado = JsonConvert.DeserializeObject<Deputado>(result);

                    Foto.Source = deputado.FotoURL;
                    //Foto.ScaleX = 2;
                    //Foto.ScaleY = 4;
                    NomeParlamentar.Text = deputado.NomeParlamentar;
                    NomeCompleto.Text = deputado.NomeCompleto;
                    Partido.Text = deputado.Partido;
                    Estado.Text = deputado.Uf;
                    GastosTotais.Text = String.Format("{0:C}", deputado.GastoTotal);
                    GastosDia.Text = String.Format("{0:C}", deputado.GastoPorDia);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        async void OnBtFrequenciaClicked(object sender, ClickedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new FrequenciaDeputado(deputado.Id, deputado.NomeParlamentar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBtDetComissoesClicked(object sender, ClickedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new ComissoesDeputado(deputado.Id, deputado.NomeParlamentar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBtProjLeiClicked(object sender, ClickedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new ProjLeiDeputado(deputado.Id, deputado.NomeParlamentar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBtTiposGastosClicked(object sender, ClickedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new TiposGastosDeputado(deputado.Id, deputado.NomeParlamentar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBtEvolGastosClicked(object sender, ClickedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new EvolucaoGastosDeputado(deputado.Id, deputado.NomeParlamentar, deputado.Mandato));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
