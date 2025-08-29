using HotReload;

public abstract class HotReloadHandler : IHotReload
{
    public abstract void Refresh(Type[]? updatedTypes);
}
