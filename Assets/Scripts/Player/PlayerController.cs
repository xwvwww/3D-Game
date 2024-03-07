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



    private CharacterController _characterController;

    private Vector3 _newPlayerPosition;
    private Vector3 _newRotationCamera;
    private Vector3 _newRotationPlayer;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector3 direction = transform.right * _inputHandler.MoveInput.x + 
                            transform.forward * _inputHandler.MoveInput.y;

        if (direction.magnitude > 1f)
            direction.Normalize();

        float speed = _inputHandler.SprintPress ? _sprintSpeed : _walkSpeed;

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


}
