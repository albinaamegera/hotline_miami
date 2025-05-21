using UnityEngine;

public interface ICharacterController
{
    public Vector2 MoveDirection { get; }
    public Vector2 LookDirection { get; }
    public Transform Transform { get; }
}
