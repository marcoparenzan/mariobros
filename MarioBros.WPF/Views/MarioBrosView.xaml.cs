using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace MarioBros.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MarioBrosView : Window, ILcdGameServices
    {
        public MarioBrosView()
        {
            InitializeComponent();

            var viewModel = new MarioBrosViewModel(this);
            DataContext = viewModel;

            var timer = new DispatcherTimer(); // DispatcherPriority.Normal, Dispatcher
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += (s, e) =>
            {
                Dispatcher.InvokeAsync(viewModel.Clock);
            };
            timer.Start();
            
        }

        private readonly TimeSpan Zero = new TimeSpan();

        void ILcdGameServices.Play(string name)
        {
            switch (name)
            {
                case "miss1":
                    miss1.Position = Zero;
                    miss1.Play();
                    break;
                case "miss2":
                    miss2.Position = Zero;
                    miss2.Play();
                    break;
                case "movebox":
                    movebox.Position = Zero;
                    movebox.Play();
                    break;
                case "movechar":
                    movechar.Position = Zero;
                    movechar.Play();
                    break;
                case "point":
                    point.Position = Zero;
                    point.Play();
                    break;
                default:
                    MessageBox.Show("Play not found");
                    break;
            }
        }

        void ILcdGameServices.Execute(Action action)
        {
            Dispatcher.InvokeAsync(action);
        }

        private void Snapshot(Stream stream, int dpi = 96)
        {
            var rtb = new RenderTargetBitmap(
                (int)this.Width, //width 
                (int)this.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
            );
            rtb.Render(this);

            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(rtb));
            enc.Save(stream);
        }

        private void movebox_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
