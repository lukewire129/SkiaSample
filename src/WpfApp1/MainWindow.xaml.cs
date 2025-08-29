using SkiaCode;
using SkiaSharp;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent ();
        }

        private void OnPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear (SKColors.Black);


            int width = e.Info.Width;
            int height = e.Info.Height;

            // 🔥 그라디언트 원형 배경
            canvas.CreateGradiantCircle (width, height);

            // 🌌 회전하는 별 같은 효과
            canvas.CreateStart(width, height);


            // 💫 네온 스타일 텍스트
            canvas.CreateNeonText (width, height);
        }
    }
}