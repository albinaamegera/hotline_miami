using UnityEngine;

public class CharacterMovementController
{
    private ICharacterController _controller;
    private float _speed;
    public CharacterMovementController(ICharacterController controller, float speed)
    {
        _controller = controller;
        _speed = speed;
    }
    public void Move()
    {
        _controller.Transform.position += (Vector3)_controller.MoveDirection * _speed * Time.deltaTime;
    }
}
