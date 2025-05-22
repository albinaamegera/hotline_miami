using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ICharacterController
{
    public Vector2 MoveDirection { get => _moveDirection.normalized; }
    public Vector2 LookDirection { get => _lookDirection; }
    public Transform Transform { get => transform; }

    [Header("input")]
    [SerializeField] private InputAction _movement;
    [SerializeField] private InputAction _rotation;
    [SerializeField] private InputAction _attack;

    [Header("settings")]
    [SerializeField] private CharacterConfig _config;

    private CharacterMovementController _moveController;
    private CharacterRotationController _lookController;
    private CharacterAttackController _attackController;

    private Vector2 _moveDirection;
    private Vector2 _lookDirection;
    private bool _isMovementInput;
    private bool _isAttackInput;
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
        if (_isAttackInput)
        {
            _attackController.Attack();
        }
        _lookController.Look();
    }
    private void OnDestroy()
    {
        DisableInput();
    }
    private void InitControllers()
    {
        _moveController = new(this, _config.movementSpeed);
        _lookController = new(this);
        _attackController = new(this);
    }
    #region input handling
    private void HandleAxis(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
    private void HandleMovementInput(InputAction.CallbackContext context)
    {
        _isMovementInput = context.phase == InputActionPhase.Started ? true : false;
    }
    private void HandleMousePosition(InputAction.CallbackContext context)
    {
        _lookDirection = context.ReadValue<Vector2>().ToWorldPoints();
    }
    private void HandleAttackInput(InputAction.CallbackContext context)
    {
        _isAttackInput = context.phase == InputActionPhase.Started ? true : false;
    }
    private void EnableInput()
    {
        _movement.Enable();
        _rotation.Enable();
        _attack.Enable();
        _movement.performed += HandleAxis;
        _movement.started += HandleMovementInput;
        _movement.canceled += HandleMovementInput;
        _rotation.performed += HandleMousePosition;
        _attack.started += HandleAttackInput;
        _attack.canceled += HandleAttackInput;
    }
    private void DisableInput()
    {
        _attack.started -= HandleAttackInput;
        _attack.canceled -= HandleAttackInput;
        _rotation.performed -= HandleMousePosition;
        _movement.performed -= HandleAxis;
        _movement.started -= HandleMovementInput;
        _movement.canceled -= HandleMovementInput;
        _attack.Disable();
        _rotation.Disable();
        _movement.Disable();
    }
    #endregion
}
