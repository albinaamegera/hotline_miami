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

    [Header("settings")]
    [SerializeField] private CharacterConfig _config;

    private CharacterMovementController _moveController;
    private CharacterRotationController _lookController;

    private Vector2 _moveDirection;
    private Vector2 _lookDirection;
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
    private void HandleMousePosition(InputAction.CallbackContext context)
    {
        _lookDirection = context.ReadValue<Vector2>().ToWorldPoints();
    }
    private void EnableInput()
    {
        _movement.Enable();
        _rotation.Enable();
        _movement.performed += HandleAxis;
        _movement.started += HandleNovementInput;
        _movement.canceled += HandleNovementInput;
        _rotation.performed += HandleMousePosition;
    }
    private void DisableInput()
    {
        _rotation.performed -= HandleMousePosition;
        _movement.performed -= HandleAxis;
        _movement.started -= HandleNovementInput;
        _movement.canceled -= HandleNovementInput;
        _rotation.Disable();
        _movement.Disable();
    }
    #endregion
}
