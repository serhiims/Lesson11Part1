using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class Settings : ScriptableObject
{
    public string playerPrefabResourceName;
    public Vector2 startingPosition;
    public float startingRotation;

    public float maxSpeed;
    public float throttleSpeed = 3f;
    public float slowdownSpeed = 2f;
    public float rotateSpeed = 3f;
    public float moveSpeed = 0.05f;
}
