using UnityEngine;

public class Scorer: MonoBehaviour
{
    private static int _score;

    public void Up()
    {
        _score++;
        Show();
    }
    
    public void Down()
    {
        _score--;
        Show();
    }

    private static void Show() 
        => Debug.Log($"Score: {_score}");
}