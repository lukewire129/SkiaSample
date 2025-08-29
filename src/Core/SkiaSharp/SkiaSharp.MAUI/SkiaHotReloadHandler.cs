using SkiaSharp.Views.Maui.Controls;

namespace SkiaSharp.MAUI;
public class SkiaHotReloadHandler : HotReloadHandler
{
    public override void Refresh(Type[]? updatedTypes)
    {
        MainThread.BeginInvokeOnMainThread (() =>
        {
            foreach (var type in updatedTypes ?? Array.Empty<Type> ())
            {
                var mainPage = Application.Current?.MainPage;
                if (mainPage != null)
                {
                    foreach (var skia in FindVisualChildren<SKCanvasView> (mainPage))
                    {
                        // 그냥 다시 그리도록 요청
                        skia.InvalidateSurface ();
                    }

                    foreach (var skia in FindVisualChildren<SKGLView> (mainPage))
                    {
                        skia.InvalidateSurface ();
                    }
                }
            }
        });
    }

    /// <summary>
    /// MAUI Visual Tree 안에서 특정 타입의 자식 요소 모두 찾기
    /// (ContentPage → Layout → View 탐색)
    /// </summary>
    private static IEnumerable<T> FindVisualChildren<T>(Element parent) where T : Element
    {
        if (parent == null)
            yield break;

        if (parent is T t)
            yield return t;

        if (parent is IElementController controller)
        {
            foreach (var child in controller.LogicalChildren)
            {
                foreach (var descendant in FindVisualChildren<T> (child))
                    yield return descendant;
            }
        }
    }
}