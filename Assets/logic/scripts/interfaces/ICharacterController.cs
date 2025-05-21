using UnityEngine;

public interface ICharacterController
{
    public Vector2 MoveDirection { get; }
    public Transform Transform { get; }
}
