using UnityEngine.InputSystem;

namespace Players.Moving
{
    public class Player2Mover : PlayerMover
    {
        protected override InputAction PlayerMovementControls => PlayerControlSystem.Default.Player2Movement;
    }
}