using UnityEngine.InputSystem;

namespace Players.Serving
{
    public class Player1BallServer : BallServer
    {
        protected override InputAction PlayerBallControls => PlayerControlSystem.Default.Player1Serve;
    }
}