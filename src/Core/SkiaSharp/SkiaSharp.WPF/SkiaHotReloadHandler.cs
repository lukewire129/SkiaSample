using SkiaSharp.Views.WPF;
using System.Windows;
using System.Windows.Media;

namespace SkiaSharp.WPF;
public class SkiaHotReloadHandler : HotReloadHandler
{
    public override void Refresh(Type[]? updatedTypes)
    {
        Application.Current.Dispatcher.Invoke (() =>
        {
            foreach (var type in updatedTypes ?? Array.Empty<Type> ())
            {
                foreach (Window win in Application.Current.Windows)
                {
                    foreach (var skia in FindVisualChildren<SKElement> (win))
                    {
                        skia.InvalidateVisual ();
                    }

                    foreach (var skia in FindVisualChildren<SKGLElement> (win))
                    {
                        skia.InvalidateVisual ();
                    }
                }
            }
        });
    }

    /// <summary>
    /// WPF Visual Tree 안에서 특정 타입의 자식 요소 모두 찾기
    /// </summary>
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
    {
        if (parent == null)
            yield break;

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount (parent); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild (parent, i);
            if (child is T t)
                yield return t;

            foreach (var descendant in FindVisualChildren<T> (child))
                yield return descendant;
        }
    }
}
