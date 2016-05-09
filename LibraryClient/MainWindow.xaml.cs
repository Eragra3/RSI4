using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using LibraryClient.LibraryServiceReference;
using Microsoft.Win32;

namespace LibraryClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _fileToUploadData;

        public MainWindow()
        {
            InitializeComponent();


            var dummy1Path = @"C:\School\RSI\cupcake.jpg";
            var dummy2Path = @"C:\School\RSI\texture.jpg";
            var dummy3Path = @"C:\School\RSI\git.png";

            var pictures = new List<PictureListModel>(100)
            {
                new PictureListModel
                {
                    Title = "Cupcake",
                    FullFileName = dummy1Path
                },
                new PictureListModel
                {
                    Title = "Texture",
                    FullFileName = dummy2Path
                },
                new PictureListModel
                {
                    Title = "Git",
                    FullFileName = dummy3Path
                }
            };
            PicturesListView.ItemsSource = pictures;
        }

        private void ChooseFileButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.png, *.jpg, *jpeg)|*.png;*.jpg;*jpeg)"
            };


            if (!(dialog.ShowDialog() ?? false)) return;

            using (var streamReader = new StreamReader(dialog.OpenFile()))
            {
                _fileToUploadData = streamReader.ReadToEnd();
            }
            FileToUploadNameTextBox.Text = dialog.FileName;
        }

        private void UploadFileButtonClick(object sender, RoutedEventArgs e)
        {
            //send file
            _fileToUploadData = null;
        }

        private void PicturesListView_OnSelected(object sender, RoutedEventArgs e)
        {
        }

        private void PicturesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;

            var fileName = ((PictureListModel)e.AddedItems[0]).FullFileName;
            var Title = ((PictureListModel)e.AddedItems[0]).Title;

            //download file
            var fileData = File.ReadAllBytes(fileName);
            //

            using (MemoryStream ms = new MemoryStream(fileData))
            {
                ms.Position = 0;
                var i = BitmapFrame.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                PictureContentImage.Source = i;
            }

            PictureTitleLabel.Content = Title;
        }
    }
}
