using UnityEngine;
using UnityEngine.InputSystem;

namespace Players.Moving
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerMover : MonoBehaviour
    {
        [SerializeField] protected float speed = 3f;

        protected PlayerControls PlayerControlSystem;

        protected abstract InputAction PlayerMovementControls { get; }

        private Vector2 _movementDirection;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            PlayerControlSystem = new PlayerControls();
            PlayerControlSystem.Enable();

            PlayerMovementControls.Enable();
            PlayerMovementControls.started += ChangeDirection;
        }

        private void Update()
        {
            Move();
        }

        private void ChangeDirection(InputAction.CallbackContext context)
            => _movementDirection = context.ReadValue<Vector2>();

        private void Move() => _rigidbody.AddForce(
            new Vector3(0, _movementDirection.y, _movementDirection.x) * (speed * Time.deltaTime),
            ForceMode.Impulse);

        private void OnDisable()
        {
            PlayerMovementControls.started -= ChangeDirection;
            PlayerMovementControls.Disable();
            PlayerControlSystem.Disable();
        }
    }
}