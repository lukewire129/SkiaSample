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
        private float baseWidth = 1920f;
        private float baseHeight = 1080f;

        public MainWindow()
        {
            InitializeComponent ();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged (sizeInfo);

            this.skia.InvalidateMeasure ();
        }

        private void OnPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear (SKColors.Black);

            int width = e.Info.Width;
            int height = e.Info.Height;

            // 💡 화면 대비 비율 유지
            float scaleX = width / (float)baseWidth;   // 화면 가로 대비 가로
            float scaleY = height / (float)baseHeight; // 화면 세로 대비 세로

            // 💥 화면 꽉 채움: 비율 유지하면서 화면 전체에 맞춤
            float scale = Math.Max (scaleX, scaleY);

            // 캔버스 중앙 기준으로 스케일 적용
            canvas.Save ();
            canvas.Translate (width / 2f, height / 2f);  // 화면 중앙 이동
            canvas.Scale (scale);                         // 스케일 적용
            canvas.Translate (-width / 2f, -height / 2f); // 원점 맞춤

            // 🔥 그라디언트 원형 배경
            canvas.CreateGradiantCircle (width, height);

            // 🌌 회전하는 별 같은 효과
            canvas.CreateStart(width, height);

            // 💫 네온 스타일 텍스트
            canvas.CreateNeonText (width, height);

            canvas.Restore (); // 원래 좌표계 복원
        }
    }
}