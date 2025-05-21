using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ICharacterController
{
    public Vector2 MoveDirection { get => _moveDirection.normalized; }
    public Transform Transform { get => transform; }

    [Header("input")]
    [SerializeField] private InputAction _movement;

    [Header("settings")]
    [SerializeField] private CharacterConfig _config;

    private CharacterMovementController _moveController;
    private Vector2 _moveDirection;
    private bool _isMovementInput;
    private void Awake()
    {
        EnableInput();
        InitControllers();
    }
    private void Update()
    {
        if (_isMovementInput)
        {
            _moveController.Move();
        }
    }
    private void OnDestroy()
    {
        DisableInput();
    }
    private void InitControllers()
    {
        _moveController = new(this, _config.movementSpeed);
    }
    #region input handling
    private void HandleAxis(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
    private void HandleNovementInput(InputAction.CallbackContext context)
    {
        _isMovementInput = context.phase == InputActionPhase.Started ? true : false;
    }
    private void EnableInput()
    {
        _movement.Enable();
        _movement.performed += HandleAxis;
        _movement.started += HandleNovementInput;
        _movement.canceled += HandleNovementInput;
    }
    private void DisableInput()
    {
        _movement.performed -= HandleAxis;
        _movement.started -= HandleNovementInput;
        _movement.canceled -= HandleNovementInput;
        _movement.Disable();
    }
    #endregion
}
