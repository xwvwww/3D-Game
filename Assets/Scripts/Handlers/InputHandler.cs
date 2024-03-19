using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private InputActions _actions;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; } 
    public bool SprintPress { get; private set; }
    public bool JumpPress { get; private set; }
    public bool ShootPress { get; private set; }
    public bool ReloadPress { get; private set; }
    public bool AimPress { get; private set; }

    private void Awake()
    {
        _actions = new InputActions();
        _actions.Enable();

        _actions.Player.Move.performed += OnMove;
        _actions.Player.Move.canceled += OnMove;

        _actions.Player.Sprint.performed += OnSprint;
        _actions.Player.Sprint.canceled += OnSprint;

        _actions.Player.Look.performed += OnLook;
        _actions.Player.Look.canceled += OnLook;

        _actions.Player.Jump.started += OnJump;
        _actions.Player.Jump.canceled += OnJump;

        _actions.Player.Shoot.performed += OnShoot;
        _actions.Player.Shoot.canceled += OnShoot;

        _actions.Player.Reload.started += OnReload;
        _actions.Player.Reload.canceled += OnReload;

        _actions.Player.Aim.performed += OnAim;
        _actions.Player.Aim.canceled += OnAim;
    }

    private void OnAim(InputAction.CallbackContext context)
    {
        AimPress = context.ReadValueAsButton();
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        ReloadPress = context.ReadValueAsButton();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        ShootPress = context.ReadValueAsButton();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        JumpPress = context.ReadValueAsButton();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        SprintPress = context.ReadValueAsButton();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
