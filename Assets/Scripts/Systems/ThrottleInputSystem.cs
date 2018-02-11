using Entitas;
using UnityEngine;

public class ThrottleInputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ThrottleInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var verticalAxisValue = Input.GetAxisRaw("Vertical");
        _contexts.game.ReplaceThrottleInput(verticalAxisValue);
    }
}
