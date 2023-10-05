using UnityEngine;

public class PlayerGates: MonoBehaviour
{
    private Scorer _scorer;

    private void Awake()
    {
        _scorer = FindObjectOfType<Scorer>();
    }
    
    // Пропуск, удаление мяча, вычет очков
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<BallController>(out var ball))
        {
            return;
        }
        
        _scorer.Down();
        
        ball.RemoveFromGame();
    }
}