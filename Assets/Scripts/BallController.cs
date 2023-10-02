using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController: MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 startingPosition = Vector3.zero;
    
    public bool IsGrabbed { get; private set; }
    public bool IsMoving { get; private set; }

    private Vector3 _movingDirection;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.position = startingPosition;
    }

    // Стенки/блоки/игроки
    private void OnCollisionExit(Collision other)
    {
        _movingDirection = Vector3.Reflect(_movingDirection, other.GetContact(0).normal);
    }

    private void Update()
    {
        if (!IsMoving || IsGrabbed)
        {
            return;
        }

        _rigidbody.velocity = _movingDirection * (speed * Time.deltaTime);
    }

    public void Grab(Transform player)
    {
        if (IsGrabbed || IsMoving)
        {
            return;
        }

        transform.position = player.position;
        transform.rotation = player.rotation;

        IsMoving = false;
        IsGrabbed = true;
    }

    public void Serve()
    {
        if (!IsGrabbed || IsMoving)
        {
            return;
        }
        
        _movingDirection = Vector3.forward;

        IsMoving = true;
        IsGrabbed = false;
    }
    
    public void RemoveFromGame()
    {
        if (!IsMoving || IsGrabbed)
        {
            return;
        }

        IsMoving = false;
        IsGrabbed = false;
        
        transform.position = startingPosition;
    }
}