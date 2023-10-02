using UnityEngine.InputSystem;

namespace Players
{
    public class Player2Controller : PlayerController
    {
        protected override InputAction PlayerMovementControls => PlayerControlSystem.Default.Player2Movement;
        protected override InputAction PlayerBallControls => PlayerControlSystem.Default.Player2Serve;
    }
}