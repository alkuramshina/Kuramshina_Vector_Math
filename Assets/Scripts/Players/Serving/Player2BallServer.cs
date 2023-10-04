using UnityEngine.InputSystem;

namespace Players.Serving
{
    public class Player2BallServer : BallServer
    {
        protected override InputAction PlayerBallControls => PlayerControlSystem.Default.Player2Serve;
    }
}