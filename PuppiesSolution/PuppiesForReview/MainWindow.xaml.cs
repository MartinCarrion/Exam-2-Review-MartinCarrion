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

namespace PuppiesForReview
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
                var Response = client.GetAsync(@"https://dog.ceo/dog-api/documentation/").Result;
                var Content = Response.Content.ReadAsStringAsync().Result;

                var Dog = JsonConvert.DeserializeObject<Breed>(Content);

                txtEnterDog.Text = "";
                if (Content=="cattledog")
                {

                }

            } 
            


        }
    }
}
