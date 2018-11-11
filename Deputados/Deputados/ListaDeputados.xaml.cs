using Deputados.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class ListaDeputados : ContentPage
    {
        public List<Deputado> deputados;

        public ListaDeputados()
        {
            InitializeComponent();
            try
            {
                CarregaDeputados("");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item == null)
                    return;

                var listView = (ListView)sender;
                Deputado deputado = (Deputado)listView.SelectedItem;
                //DisplayAlert("Item Tapped", deputado.NomeParlamentar, "OK");
                await Navigation.PushAsync(new DetalhesDeputado(deputado.Id));
                //Deselect Item
                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.Items[selectedIndex])
                {
                    case "Todos os estados":
                        CarregaDeputados("");
                        break;
                    case "Acre":
                        CarregaDeputados("AC");
                        break;
                    case "Alagoas":
                        CarregaDeputados("AL");
                        break;
                    case "Amapá":
                        CarregaDeputados("AP");
                        break;
                    case "Amazonas":
                        CarregaDeputados("AM");
                        break;
                    case "Bahia":
                        CarregaDeputados("BA");
                        break;
                    case "Ceará":
                        CarregaDeputados("CE");
                        break;
                    case "Distrito Federal":
                        CarregaDeputados("DF");
                        break;
                    case "Espírito Santo":
                        CarregaDeputados("ES");
                        break;
                    case "Goiás":
                        CarregaDeputados("GO");
                        break;
                    case "Maranhão":
                        CarregaDeputados("MA");
                        break;
                    case "Mato Grosso":
                        CarregaDeputados("MT");
                        break;
                    case "Mato Grosso do Sul":
                        CarregaDeputados("MS");
                        break;
                    case "Minas Gerais":
                        CarregaDeputados("MG");
                        break;
                    case "Pará":
                        CarregaDeputados("PA");
                        break;
                    case "Paraíba":
                        CarregaDeputados("PB");
                        break;
                    case "Paraná":
                        CarregaDeputados("PR");
                        break;
                    case "Pernambuco":
                        CarregaDeputados("PE");
                        break;
                    case "Piauí":
                        CarregaDeputados("PI");
                        break;
                    case "Rio de Janeiro":
                        CarregaDeputados("RJ");
                        break;
                    case "Rio Grande do Norte":
                        CarregaDeputados("RN");
                        break;
                    case "Rio Grande do Sul":
                        CarregaDeputados("RS");
                        break;
                    case "Rondônia":
                        CarregaDeputados("RO");
                        break;
                    case "Roraima":
                        CarregaDeputados("RR");
                        break;
                    case "Santa Catarina":
                        CarregaDeputados("SC");
                        break;
                    case "São Paulo":
                        CarregaDeputados("SP");
                        break;
                    case "Sergipe":
                        CarregaDeputados("SE");
                        break;
                    case "Tocantins":
                        CarregaDeputados("TO");
                        break;
                    default:
                        CarregaDeputados("");
                        break;
                }
            }
        }

        async void CarregaDeputados(String estado)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    var uri = estado.Equals("") ?
                            "http://meucongressonacional.com/api/001/deputado" :
                            "http://meucongressonacional.com/api/001/deputado/estado/" + estado;
                    var result = await client.GetStringAsync(uri);
                    deputados = JsonConvert.DeserializeObject<List<Deputado>>(result);
                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Deputado>>(result);
                    var post = posts.First();
                    MyListView.ItemsSource = posts;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        
    }
}
