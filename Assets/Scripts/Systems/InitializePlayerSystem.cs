using Entitas;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        var settings = _contexts.game.settings.value;

        entity.AddResource(settings.playerPrefabResourceName);
        entity.AddPosition(settings.startingPosition.x, settings.startingPosition.y);
        entity.AddRotation(settings.startingRotation);
        entity.AddInertia(0f);
        entity.isPlayer = true;
    }
}
