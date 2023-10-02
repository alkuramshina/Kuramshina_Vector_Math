using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerController : MonoBehaviour
    {
        [SerializeField] protected float speed = 3f;
        
        protected PlayerControls PlayerControlSystem;

        protected abstract InputAction PlayerMovementControls { get; }
        protected abstract InputAction PlayerBallControls { get; }
        
        private Vector2 _movementDirection;

        private Rigidbody _rigidbody;
        private BallController _ball;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ball = FindObjectOfType<BallController>();

            PlayerControlSystem = new PlayerControls();
            PlayerControlSystem.Enable();
            
            PlayerBallControls.Enable();
            PlayerBallControls.performed += InteractWithBall;
            
            PlayerMovementControls.Enable();
            PlayerMovementControls.started += ChangeDirection;
        }

        private void Update()
        {
            Move();
        }

        private void InteractWithBall(InputAction.CallbackContext context)
        {
            // Если уже летает - не трогать
            if (_ball.IsMoving)
            {
                return;
            }

            // Если в руках - запустить
            if (_ball.IsGrabbed)
            {
                _ball.Serve();
            }
            
            // Иначе "взять в руки"
            _ball.Grab(transform);
        }
        
        private void ChangeDirection(InputAction.CallbackContext context)
            => _movementDirection = context.ReadValue<Vector2>();

        private void Move() => _rigidbody.AddForce(
            new Vector3(0, _movementDirection.y, _movementDirection.x) * (speed * Time.deltaTime),
            ForceMode.Impulse);

        private void OnDisable()
        {
            PlayerMovementControls.started -= ChangeDirection;
            PlayerBallControls.performed -= InteractWithBall;
            
            PlayerBallControls.Disable();
            PlayerMovementControls.Disable();
            PlayerControlSystem.Disable();
        }
    }
}