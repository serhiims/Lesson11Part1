using Entitas;
using UnityEngine;
using System;

public class InputPositionSystem : IExecuteSystem
{
	private Contexts _contexts;

	public InputPositionSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Execute()
	{
		var verticalAxisValue = Input.GetAxisRaw("Vertical");
		var playerEntity = _contexts.game.playerEntity;
        var settings = _contexts.game.settings.value;
        var rotationRad = (playerEntity.rotation.value - settings.startingRotation) / Mathf.Rad2Deg;
        var distance = verticalAxisValue * settings.moveSpeed * Time.deltaTime;
        var deltaPosition = GetPolarPosition(distance, rotationRad);
        playerEntity.ReplacePosition(playerEntity.position.x - deltaPosition.x, playerEntity.position.y - deltaPosition.y);
	}

    private Vector2 GetPolarPosition(float distance, float rad)
    {
        return new Vector2(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));
    }
}
