using Entitas;
using UnityEngine;

public class InputRotationSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputRotationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
		var horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        var playerEntity = _contexts.game.playerEntity;
        var rotation = playerEntity.rotation.value -
                       horizontalAxisValue * _contexts.game.settings.value.rotateSpeed * Time.deltaTime;

        playerEntity.ReplaceRotation(rotation);
    }
}
