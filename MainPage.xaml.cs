using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoryGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int subjectIndex = ComboSubject.SelectedIndex;
            int levelIndex = ComboLevel.SelectedIndex;

            if(subjectIndex != -1 && levelIndex != -1)
            {
                Level level;
                if (levelIndex == 0)
                    level = Level.lvl1;
                else if (levelIndex == 1)
                    level = Level.lvl2;
                else
                    level = Level.lvl3;

                Subject subject;
                if (subjectIndex == 0)
                    subject = Subject.Flags;
                else
                    subject = Subject.Games;

                Data data = new Data(subject, level);
                Frame.Navigate(typeof(MemoGame), data);
            }
        }
    }
}
