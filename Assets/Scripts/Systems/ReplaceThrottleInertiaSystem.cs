using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ReplaceThrottleInertiaSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ReplaceThrottleInertiaSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ThrottleInput);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasThrottleInput;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var settings = _contexts.game.settings.value;
        foreach (var entity in entities)
        {
            var playerEntity = _contexts.game.playerEntity;
            var inertiaValue = playerEntity.inertia.value;
            var deltaTime = Time.deltaTime;

            var addedThrottle = entity.throttleInput.value > 0f
                ? settings.throttleSpeed * deltaTime
                : -settings.slowdownSpeed * deltaTime;

            playerEntity.ReplaceInertia(inertiaValue + addedThrottle);
        }
    }
}
