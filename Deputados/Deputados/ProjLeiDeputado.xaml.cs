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
    public partial class ProjLeiDeputado : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ProjLeiDeputado()
        {
            InitializeComponent();
        }

        public ProjLeiDeputado(Int32 idDep, String nome)
        {
            InitializeComponent();

            CarregaComissoesDeputado(idDep);
            NomeParlamentar.Text = nome;
        }

        async void CarregaComissoesDeputado(Int32 idDep)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://meucongressonacional.com/api/001/deputado/" + idDep + "/projetos";
                    var result = await client.GetStringAsync(uri);

                    var posts = JsonConvert.DeserializeObject<ObservableCollection<ProjetoLei>>(result);
                    listView.ItemsSource = posts;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item == null)
                    return;

                var listView = (ListView)sender;
                ProjetoLei projetoLei = (ProjetoLei)listView.SelectedItem;
                await DisplayAlert("Ementa",projetoLei.Ementa, "OK");

                //Deselect Item
                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
