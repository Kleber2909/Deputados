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
    public partial class FrequenciaDeputado : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public FrequenciaDeputado()
        {
            InitializeComponent();
        }

        public FrequenciaDeputado(Int32 idDep, String nome)
        {
            InitializeComponent();

            CarregaFrequenciaDeputado(idDep);
            NomeParlamentar.Text = nome;
        }

        async void CarregaFrequenciaDeputado(Int32 idDep)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://meucongressonacional.com/api/001/deputado/" + idDep + "/freq";
                    var result = await client.GetStringAsync(uri);

                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Frequencia>>(result);
                    listView.ItemsSource = posts;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
