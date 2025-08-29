using SkiaSharp;

namespace SkiaCode
{
    public static class GradiantCircle
    {
        public static void CreateGradiantCircle(this SKCanvas canvas, float width, float height)
        {
            var center = new SKPoint (width / 2f, height / 2f);
            using (var paint = new SKPaint ())
            {
                paint.IsAntialias = true;
                paint.Shader = SKShader.CreateRadialGradient (
                center,
                width / 1.2f,
                new SKColor[] { SKColors.DeepSkyBlue, SKColors.MediumPurple, SKColors.Black },
                null,
                SKShaderTileMode.Clamp);


                canvas.DrawCircle (center, width / 1.2f, paint);
            }
        }

        public static void CreateStart(this SKCanvas canvas, int width, int height)
        {
            using (var starPaint = new SKPaint ())
            {
                starPaint.IsAntialias = true;
                starPaint.Style = SKPaintStyle.Fill;
                starPaint.Color = SKColors.White.WithAlpha (200);


                var random = new Random ();
                for (int i = 0; i < 50; i++)
                {
                    float x = random.Next (width);
                    float y = random.Next (height);
                    float r = (float)random.NextDouble () * 3f;
                    canvas.DrawCircle (x, y, r, starPaint);
                }
            }
        }

        public static void CreateNeonText(this SKCanvas canvas, int width, int height)
        {
            var center = new SKPoint (width / 2f, height / 2f);
            using (var textPaint = new SKPaint ())
            {
                textPaint.IsAntialias = true;
                textPaint.TextSize = 96;
                textPaint.Typeface = SKTypeface.FromFamilyName ("Arial", SKFontStyle.Bold);
                textPaint.TextAlign = SKTextAlign.Center;


                textPaint.Color = SKColors.Cyan.WithAlpha (200);
                textPaint.ImageFilter = SKImageFilter.CreateBlur (10, 10);
                canvas.DrawText ("SKIA MAGIC", center.X, center.Y, textPaint);


                textPaint.ImageFilter = null;
                textPaint.Color = SKColors.White;
                canvas.DrawText ("SKIA MAGIC", center.X, center.Y, textPaint);
            }
        }
    }
}
