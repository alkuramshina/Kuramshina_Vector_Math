using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerMover : MonoBehaviour
    {
        [SerializeField] protected float Speed = 3f;
        protected PlayerControls PlayerControlSystem;

        protected abstract InputAction PlayerMovementControls { get; }
        private Vector2 _movementDirection;

        private Rigidbody _rigidbody;
        private BallController _ballController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ballController = FindObjectOfType<BallController>();

            PlayerControlSystem = new PlayerControls();
            PlayerControlSystem.Enable();
            PlayerControlSystem.Default.Serve.performed += ServeBall;
            
            PlayerMovementControls.Enable();
            PlayerMovementControls.started += ChangeDirection;
        }

        private void Update()
        {
            Move();
        }

        private void ServeBall(InputAction.CallbackContext context)
        {
            _ballController.Serve(transform.position);
        }
        
        private void ChangeDirection(InputAction.CallbackContext context)
            => _movementDirection = context.ReadValue<Vector2>();

        private void Move()
            => _rigidbody.AddForce(new Vector3(0, _movementDirection.y, _movementDirection.x) * (Speed * Time.deltaTime), 
                ForceMode.Impulse);

        private void OnDisable()
        {
            PlayerMovementControls.started -= ChangeDirection;
            PlayerControlSystem.Default.Serve.performed -= ServeBall;
            PlayerMovementControls.Disable();
            PlayerControlSystem.Disable();
        }
    }
}