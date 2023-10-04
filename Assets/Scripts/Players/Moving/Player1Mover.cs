using UnityEngine.InputSystem;

namespace Players.Moving
{
    public class Player1Mover : PlayerMover
    {
        protected override InputAction PlayerMovementControls => PlayerControlSystem.Default.Player1Movement;
    }
}