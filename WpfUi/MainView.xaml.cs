using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace WpfUi
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == false)
                return;

            string path = openFileDialog.FileName;

            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(path);
            myBitmapImage.EndInit();
            imgSource.Source = myBitmapImage;


            byte[] pixels = BitmapSourceToArray(myBitmapImage);
            byte[] pixelsInvert = new byte[pixels.Length];


            //Filter 1
            //IntPtr ptr = BitmapFiltersAPI.CreateBitmapFilter();
            //Filter 2
            IntPtr ptr = BitmapFiltersAPI.CreateBitmapFilterNegative();
            //Filter 3
            //IntPtr ptr = BitmapFiltersAPI.CreateBitmapFilterRed();
            BitmapFiltersAPI.SetPixels(ptr, pixels, pixels.Length);
            BitmapFiltersAPI.Update(ptr);
            //System.Threading.Thread.Sleep(1000);
            int length = 0;            
            IntPtr intPtrBytes = BitmapFiltersAPI.GetPixels(ptr, ref length);
            Marshal.Copy(intPtrBytes, pixelsInvert, 0, length);
            BitmapFiltersAPI.Dispose(ptr);


            BitmapSource bitmapSource = BitmapSourceFromArray(pixelsInvert, myBitmapImage.PixelWidth, myBitmapImage.PixelHeight);
            imgProcessed.Source = bitmapSource;
        }

        private byte[] BitmapSourceToArray(BitmapSource bitmapSource)
        {
            // Stride = (width) x (bytes per pixel)
            int stride = (int)bitmapSource.PixelWidth * (bitmapSource.Format.BitsPerPixel / 8);
            byte[] pixels = new byte[(int)bitmapSource.PixelHeight * stride];

            bitmapSource.CopyPixels(pixels, stride, 0);

            return pixels;
        }

        private BitmapSource BitmapSourceFromArray(byte[] pixels, int width, int height)
        {
            WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);

            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * (bitmap.Format.BitsPerPixel / 8), 0);

            return bitmap;
        }
    }
    
}
