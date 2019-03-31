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

namespace GOT
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var Response = client.GetAsync(@"https://got-quotes.herokuapp.com/quotes").Result;
                if (Response.IsSuccessStatusCode)
                {
                    var Content = Response.Content.ReadAsStringAsync().Result;
                    Quote q = JsonConvert.DeserializeObject<Quote>(Content);


                    txtQuote.Inlines.Add((new Italic(new Run(Content))));



                    if (Content.Contains("Tyrion"))
                    {
                        ;
                        // Create the image element.
                        Image TyrionImage = new Image();
                        TyrionImage.Width = 792;
                        TyrionImage.Height = 452;
                        TyrionImage.Margin = new Thickness(5);
                        // Create source.
                        BitmapImage bi = new BitmapImage();
                        // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                        bi.BeginInit();
                        bi.UriSource = new Uri(@"C:\Users\Martin\Desktop\download.jpg", UriKind.RelativeOrAbsolute);
                        bi.EndInit();
                        // Set the image source.
                        TyrionImage.Source = bi;
                        
                        txtImage1.Inlines.Add(TyrionImage);
                        
                    }
                    txtQuote.Text.Replace("character", " ");

                }
            }




        }
    }
}
