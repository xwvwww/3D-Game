using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Input Handler")]
    [SerializeField] private InputHandler _inputHandler;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _jumpHeight;

    [Header("Look")]
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] [Range(1, 30)] private float _sensX;
    [SerializeField] [Range(1, 30)] private float _sensY;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;

    [Header("Gravity")]
    [SerializeField] private float _stickToGroundForce;
    [SerializeField] private float _gravityMultiplier;

    [Header("Stamina")]
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _restoreStamina;
    [SerializeField] private float _usageStamina;
    [SerializeField] private float _delayRestoreTime;

    private CharacterController _characterController;

    private Vector3 _newPlayerPosition;
    private Vector3 _newRotationCamera;
    private Vector3 _newRotationPlayer;

    private bool _isSprint;
    private bool _isWalking;
    private float _currentStamina;
    private float _currentRestoreTime;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _currentStamina = _maxStamina;
        _currentRestoreTime = _delayRestoreTime;
    }


    private void Update()
    {
        Move();
        CalculateStamina();
        Look();
    }

    private void Move()
    {
        Vector3 direction = transform.right * _inputHandler.MoveInput.x + 
                            transform.forward * _inputHandler.MoveInput.y;

        if (direction.magnitude > 1f)
            direction.Normalize();


        if (_inputHandler.SprintPress && direction.magnitude > 0.2f && _currentStamina > 25f)
            _isSprint = true;
        else
            _isSprint = false;

        _isWalking = !_isSprint && direction.magnitude > 0.2f;

        float speed = _isWalking ? _walkSpeed : _sprintSpeed;

        if (Physics.SphereCast(transform.position, _characterController.radius ,Vector3.down,
            out RaycastHit hit, _characterController.height / 2f, 1))
        {
            direction = Vector3.ProjectOnPlane(direction, hit.normal);
        }

        _newPlayerPosition.x = direction.x * speed;
        _newPlayerPosition.z = direction.z * speed;

        if (_characterController.isGrounded)
        {
            if (_inputHandler.JumpPress)
            {
                _newPlayerPosition.y = _jumpHeight;
            }
            else
            {
                _newPlayerPosition.y = -_stickToGroundForce;
            }
        }
        else
        {
            _newPlayerPosition.y += Physics.gravity.y * _gravityMultiplier * Time.deltaTime;
        }

        _characterController.Move(_newPlayerPosition * Time.deltaTime);
    }

    private void Look()
    {
        _newRotationCamera.x += _sensY * -_inputHandler.LookInput.y * Time.deltaTime;
        _newRotationPlayer.y += _sensX * _inputHandler.LookInput.x * Time.deltaTime;

        _newRotationCamera.x = Mathf.Clamp(_newRotationCamera.x, _minAngle, _maxAngle);

        transform.localRotation = Quaternion.Euler(_newRotationPlayer);
        _cameraHolder.localRotation = Quaternion.Euler(_newRotationCamera);
    }

    private void CalculateStamina()
    {
        if (_isSprint)
        {
            if (_currentStamina > 0f)
            {
                _currentStamina -= _usageStamina * Time.deltaTime;
                _currentRestoreTime = _delayRestoreTime;
            }
        }
        else if (!_isSprint && _currentStamina < _maxStamina)
        {
            if (_currentRestoreTime > 0f)
            {
                _currentRestoreTime -= Time.deltaTime;
            }
            else
            {
                _currentStamina += _restoreStamina * Time.deltaTime;

                if (_currentStamina >= _maxStamina)
                {
                    _currentStamina = _maxStamina;
                    _currentRestoreTime = _delayRestoreTime;
                }
            }
        }

    }


}
