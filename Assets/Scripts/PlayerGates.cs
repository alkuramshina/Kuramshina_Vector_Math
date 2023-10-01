using UnityEngine;

public class PlayerGates: MonoBehaviour
{
    // Пропуск, удаление мяча, вычет очков
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<BallController>(out var ball))
        {
            return;
        }
        
        Debug.Log("Пропуск!");
        ball.RemoveFromGame();
    }
}