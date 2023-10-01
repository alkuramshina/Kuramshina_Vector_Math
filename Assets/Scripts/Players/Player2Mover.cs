using UnityEngine.InputSystem;

namespace Players
{
    public class Player2Mover : PlayerMover
    {
        protected override InputAction PlayerMovementControls => PlayerControls.Default.Player2;
    }
}