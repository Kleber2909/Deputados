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
    public partial class TiposGastosDeputado : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public TiposGastosDeputado()
        {
            InitializeComponent();
        }
        public TiposGastosDeputado(Int32 idDep, String nome)
        {
            InitializeComponent();

            CarregaGastosDeputado(idDep);
            NomeParlamentar.Text = nome;
        }

        async void CarregaGastosDeputado(Int32 idDep)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://meucongressonacional.com/api/001/deputado/" + idDep + "/gastos/tipo";
                    var result = await client.GetStringAsync(uri);

                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Gastos>>(result);
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
