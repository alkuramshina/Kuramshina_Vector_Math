using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController: MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    
    private bool _isInPlay;

    private Vector3? _movingDirection;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Стенки/блоки/игроки
    private void OnCollisionExit(Collision other)
    {
        if (_movingDirection is null)
        {
            return;
        }
        
        _movingDirection = Vector3.Reflect(_movingDirection.Value, other.GetContact(0).normal);
    }

    private void Update()
    {
        if (_movingDirection is null)
        {
            return;
        }
        
        _rigidbody.velocity = _movingDirection.Value * (Speed * Time.deltaTime);
    }

    public void Serve(Vector3 position)
    {
        if (_isInPlay)
        {
            return;
        }

        transform.position = position;
        gameObject.SetActive(true);
        
        _movingDirection = Vector3.zero;
        _isInPlay = true;
    }
    
    public void RemoveFromGame()
    {
        if (!_isInPlay)
        {
            return;
        }

        _isInPlay = false;
        _movingDirection = null;
        
        gameObject.SetActive(false);
    }
}