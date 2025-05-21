using UnityEngine;

public class CharacterRotationController
{
    private ICharacterController _controller;
    private Vector2 _direction;
    private Quaternion _targetRotation;
    private float _angle;
    public CharacterRotationController(ICharacterController controller)
    {
        _controller = controller;
    }
    public void Look()
    {
        _direction = _controller.LookDirection - (Vector2)_controller.Transform.position;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
        _targetRotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        _controller.Transform.rotation = _targetRotation;
    }
}
