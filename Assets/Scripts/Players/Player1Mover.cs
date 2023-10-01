using UnityEngine.InputSystem;

namespace Players
{
    public class Player1Mover : PlayerMover
    {
        protected override InputAction PlayerMovementControls => PlayerControls.Default.Player1;
    }
}