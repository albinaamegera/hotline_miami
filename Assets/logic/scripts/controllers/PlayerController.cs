using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction _movement;

    private void Awake()
    {
        _movement.Enable();
        _movement.performed += GetAxis;
    }
    private void GetAxis(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }
    private void OnDestroy()
    {
        _movement.performed -= GetAxis;
        _movement.Disable();
    }
}
