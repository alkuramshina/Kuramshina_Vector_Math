using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public abstract class PlayerMover : MonoBehaviour
    {
        [SerializeField] protected float Speed = 5f;
        protected PlayerControls PlayerControls;

        protected abstract InputAction PlayerMovementControls { get; }
        private Coroutine _movementCoroutine;

        private void Awake()
        {
            PlayerControls = new PlayerControls();

            PlayerMovementControls.Enable();

            PlayerMovementControls.started += Move;
            PlayerMovementControls.canceled  += StopMovement;
        }

        private void StopMovement(InputAction.CallbackContext context)
        {
            if (_movementCoroutine is null)
            {
                return;
            }
            
            StopCoroutine(_movementCoroutine);
            _movementCoroutine = null;
        }

        private void Move(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _movementCoroutine = StartCoroutine(Movement(new Vector3(0, direction.y, direction.x)));
        }

        private IEnumerator Movement(Vector3 direction)
        {
            while (true)
            {
                transform.position += direction * Speed * Time.deltaTime;
                yield return null;
            }
        }

        private void OnDisable()
        {
            PlayerMovementControls.started -= Move;
            PlayerMovementControls.canceled  -= StopMovement;

            PlayerMovementControls.Disable();
        }
    }
}