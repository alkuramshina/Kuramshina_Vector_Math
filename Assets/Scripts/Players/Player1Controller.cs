using UnityEngine.InputSystem;

namespace Players
{
    public class Player1Controller : PlayerController
    {
        protected override InputAction PlayerMovementControls => PlayerControlSystem.Default.Player1Movement;
        protected override InputAction PlayerBallControls => PlayerControlSystem.Default.Player1Serve;
    }
}