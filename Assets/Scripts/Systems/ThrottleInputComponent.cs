using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ThrottleInputComponent : IComponent
{
    public float value;
}
