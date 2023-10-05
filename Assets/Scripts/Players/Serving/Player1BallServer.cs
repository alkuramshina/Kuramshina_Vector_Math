using UnityEngine;
using UnityEngine.InputSystem;

namespace Players.Serving
{
    public class Player1BallServer : BallServer
    {
        [SerializeField] protected override Vector3 ServeDirection { get; } = new (-19.5f, 0, 0);
        protected override InputAction PlayerBallControls => PlayerControlSystem.Default.Player1Serve;
    }
}