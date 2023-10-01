using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerMover : MonoBehaviour
    {
        [SerializeField] protected float Speed = 3f;
        protected PlayerControls PlayerControls;

        protected abstract InputAction PlayerMovementControls { get; }
        private Vector2 _movementDirection;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            PlayerControls = new PlayerControls();
            _rigidbody = GetComponent<Rigidbody>();

            PlayerMovementControls.Enable();

            PlayerMovementControls.started += ChangeDirection;
        }

        private void Update()
        {
            Move();
        }
        
        private void ChangeDirection(InputAction.CallbackContext context)
            => _movementDirection = context.ReadValue<Vector2>();

        private void Move()
            => _rigidbody.AddForce(new Vector3(0, _movementDirection.y, _movementDirection.x) * Speed * Time.deltaTime, 
                ForceMode.Impulse);

        private void OnDisable()
        {
            PlayerMovementControls.started -= ChangeDirection;

            PlayerMovementControls.Disable();
        }
    }
}