using Microsoft.Extensions.DependencyInjection;

[assembly: System.Reflection.Metadata.MetadataUpdateHandler (typeof (HotReload.MetadataUpdateHandler))]
namespace HotReload;

public static class MetadataUpdateHandler
{
    private static IHotReload? _handler;

    public static void Configure(IHotReload handler)
    {
        _handler = handler;
    }

    public static void ClearCache(Type[]? types)
    {
        // 필요시 캐시 제거
    }

    public static void UpdateApplication(Type[]? types)
    {
        _handler?.Refresh (types);
    }
}

public interface IHotReload
{
    void Refresh(Type[]? updatedTypes);
}

public static class HotReloadServiceCollectionExtensions
{
    public static IServiceCollection AddHotReload<T>(this IServiceCollection services)
        where T : class, IHotReload
    {
        services.AddSingleton<IHotReload, T> ();

        // 등록 시 바로 Dispatcher와 연결
        var provider = services.BuildServiceProvider ();
        var handler = provider.GetRequiredService<IHotReload> ();
        MetadataUpdateHandler.Configure (handler);

        return services;
    }
}