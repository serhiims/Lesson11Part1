using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SetRotationSystem : ReactiveSystem<GameEntity>
{
    public SetRotationSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Rotation);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasRotation;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var transform = entity.view.value.transform;
            var rotation = Quaternion.Euler(0f, 0f, entity.rotation.value);
            transform.rotation = rotation;
        }
    }
}
