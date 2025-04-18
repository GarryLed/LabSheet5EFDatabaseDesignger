using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.Entity;

namespace Exercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MusicDBEntities db = new MusicDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            LoadBands();
        }

        // load the bands on window loadup 
        private void LoadBands()
        {
           var bands = db.Bands.ToList();

            lbxBands.ItemsSource = bands;
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxBands.SelectedItem != null) 
            {
                int selectedBandId = (int)lbxBands.SelectedValue;
                var albums = db.Albums.Where(a => a.BandId == selectedBandId).ToList();
                lbxAlbums.ItemsSource = albums;
            }
        }
    }
}
