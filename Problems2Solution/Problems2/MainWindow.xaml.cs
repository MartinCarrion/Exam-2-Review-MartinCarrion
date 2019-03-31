//a.Using the Pokemon API found here, allow the user to enter their favorite pokemon and look
//up the pokemon and list all of the pokemon's abilities (e.g.
//https://pokeapi.co/api/v2/pokemon/pikachu).
//b.For even better practice, list all of the available pokemon and allow the user to select.I
//would use a ComboBox or ListBox for the user to choose the pokemon from.To get a list of
//the pokemon, you can use https://pokeapi.co/api/v2/pokemon note that by default it only
//gives you 20 of the 900+ so you will need to either
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problems2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($@"https://pokeapi.co/api/v2/pokemon/{txtPokemon.Text}").Result;
                var content = response.Content.ReadAsStringAsync().Result;

                var poke = JsonConvert.DeserializeObject<Pokemon>(content);
                txtPokemon.Text = "";
                txtOutput.Text=$"{txtPokemon.Text} has {poke.abilities.Count} abilities:\n";
                for (int i = 0; i < poke.abilities.Count; i++)
                {
                    var abilities = poke.abilities[i];
                    txtOutput.Text += $"{i + 1}.\t{abilities.ability.name}\n";

                }


            }
            




        }
    }
}
