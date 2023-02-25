using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace MemoryGame
{
    class CardClass
    {
        public Windows.UI.Xaml.Controls.Image Image { get; set; }
        public int[] Pos1 { get; set; }
        public int[] Pos2 { get; set; }
        public bool B1Clicked { get; set; }
        public bool B2Clicked { get; set; }

        private Button button1;
        private Button button2;

        private string _defimageAdress = $"ms-appx:///BACK.png";
        private Windows.UI.Xaml.Controls.Image def_img;
        public CardClass(Windows.UI.Xaml.Controls.Image image, int[] pos1, int[] pos2)
        {
            // Get values
            this.Image = image;
            this.Pos1 = pos1;
            this.Pos2 = pos2;

            B1Clicked = false; B2Clicked = false;

            def_img = new Windows.UI.Xaml.Controls.Image();
            def_img.Source = new BitmapImage(new Uri(_defimageAdress));


            /*    //creating the button and stretccing it 
                button = new Button();
                button.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                button.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

                //make the background of the button image
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = image.Source;
                button.Background = brush;*/

            button1 = MakeAButton(pos1);
            button2 = MakeAButton(pos2);
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

        }

        private void Button2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //make the background of the button image
            ImageBrush brush = new ImageBrush();

            brush.ImageSource = Image.Source;

            button2.Background = brush;

            B2Clicked = true;
            if (B2Clicked == B1Clicked)
            {
                button1.Background = new SolidColorBrush(Colors.Red);
                button2.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //make the background of the button image
            ImageBrush brush = new ImageBrush();

            brush.ImageSource = Image.Source;

            button1.Background = brush;

            B1Clicked = true;
            if (B2Clicked == B1Clicked)
            {
                button1.Background = new SolidColorBrush(Colors.Red);
                button2.Background = new SolidColorBrush(Colors.Red);
            }
        }

        public void addToGrid(Grid grid)
        {
            grid.Children.Add(button1);
            grid.Children.Add(button2);
            



        }

        public Button MakeAButton(int[] pos)
        {
            Button button = new Button();
            button.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            button.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

            //make the background of the button image
            ImageBrush brush = new ImageBrush();

            //brush.ImageSource = Image.Source;
            brush.ImageSource = def_img.Source;
            button.Background = brush;

            Grid.SetColumn(button, pos[0]);
            Grid.SetRow(button, pos[1]);
            return button;
        }

        public bool IsOnlyOneClicked()
        {
            return !(B1Clicked == B2Clicked);
        }
        public async void reastClick()
        {
            if (B1Clicked == B2Clicked)
            {
                return;
            }
            B1Clicked = false;
            B2Clicked = false;



            ImageBrush brush = new ImageBrush();
            await Task.Delay(600);
            //brush.ImageSource = Image.Source;
            brush.ImageSource = def_img.Source;
            button1.Background = brush;
            button2.Background = brush;
        }


        public bool isRight()
        {
            return B1Clicked == B2Clicked && B1Clicked == true;
        }
    }
}
