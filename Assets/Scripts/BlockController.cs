using System;
using UnityEngine;

public class BlockController: MonoBehaviour
{
    private Scorer _scorer;

    private void Awake()
    {
        _scorer = FindObjectOfType<Scorer>();
    }

    // Удаление блока, начисление очков
    private void OnCollisionExit(Collision other)
    {
        if (!other.collider.TryGetComponent<BallController>(out var ball))
        {
            return;
        }
        
        _scorer.Up();
        
        Destroy(gameObject);
    }
}