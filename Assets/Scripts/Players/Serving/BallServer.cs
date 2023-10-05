using UnityEngine;
using UnityEngine.InputSystem;

namespace Players.Serving
{
    public abstract class BallServer : MonoBehaviour
    {
        protected abstract InputAction PlayerBallControls { get; }
        protected PlayerControls PlayerControlSystem;
        protected abstract Vector3 ServeDirection { get; }

        private bool _hasBall;
        private BallController _ball;
    
        private void Awake()
        {
            PlayerControlSystem = new PlayerControls();
            PlayerControlSystem.Enable();
            
            PlayerBallControls.Enable();
            PlayerBallControls.performed += InteractWithBall;
        
            _ball = FindObjectOfType<BallController>();
        }
    
        private void InteractWithBall(InputAction.CallbackContext context)
        {
            // Если уже летает - не трогать
            if (_ball.IsMoving)
            {
                return;
            }

            // Если в руках - запустить
            if (_hasBall)
            {
                _ball.Serve(ServeDirection);
            }

            // Иначе "взять в руки"
            if (!_ball.IsGrabbed)
            {
                _ball.Grab(transform);
                _hasBall = true;
            }
        }
    
        private void OnDisable()
        {
            PlayerBallControls.performed -= InteractWithBall;
            
            PlayerBallControls.Disable();
            PlayerControlSystem.Disable();
        }
    }
}