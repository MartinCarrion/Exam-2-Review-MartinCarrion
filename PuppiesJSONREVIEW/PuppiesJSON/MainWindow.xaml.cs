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

namespace PuppiesJSON
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
            using (HttpClient client=new HttpClient())
            {
                var Response = client.GetAsync($@"https://dog.ceo/dog-api/documentation/{txtBlock.Text} ").Result;
                var content = Response.Content.ReadAsStringAsync().Result;
                var Bree = JsonConvert.DeserializeObject<Breeds>(content);
                txtUserType.Text = "";
                txtBlock.Text = $"{txtBlock.Text} has:\n";
                if (content.Contains("cattledog"))
                {
                    Image CattleDog = new Image();
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(@"https://dog.ceo/api/breed/cattledog/images/random", UriKind.RelativeOrAbsolute);
                    bi.EndInit();
                    CattleDog.Source = bi;
                    txtBlock.Inlines.Add(CattleDog);

                }



            }
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = client.GetAsync($@"https://pokeapi.co/api/v2/pokemon/{txtPokemon.Text}").Result;
            //    var content = response.Content.ReadAsStringAsync().Result;

            //    var poke = JsonConvert.DeserializeObject<Pokemon>(content);
            //    txtPokemon.Text = "";
            //    txtOutput.Text = $"{txtPokemon.Text} has {poke.abilities.Count} abilities:\n";
            //    for (int i = 0; i < poke.abilities.Count; i++)
            //    {
            //        var abilities = poke.abilities[i];
            //        txtOutput.Text += $"{i + 1}.\t{abilities.ability.name}\n";

            //    }
            //if (Content.Contains("Tyrion"))
            //{
            //    ;
            //    // Create the image element.
            //    Image TyrionImage = new Image();
            //    TyrionImage.Width = 792;
            //    TyrionImage.Height = 452;
            //    TyrionImage.Margin = new Thickness(5);
            //    // Create source.
            //    BitmapImage bi = new BitmapImage();
            //    // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            //    bi.BeginInit();
            //    bi.UriSource = new Uri(@"C:\Users\Martin\Desktop\download.jpg", UriKind.RelativeOrAbsolute);
            //    bi.EndInit();
            //    // Set the image source.
            //    TyrionImage.Source = bi;

            //    txtImage1.Inlines.Add(TyrionImage);
            //}


            //}



        }
    }
}
