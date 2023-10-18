using System;
using UnityEngine;

public class Scorer: MonoBehaviour
{
    private static int _score;

    public event EventHandler<OnScoreChangedEventArgs> OnScoreChanged;

    public void Up()
    {
        ChangeScore(_score + 1);
        Show();
    }
    
    public void Down()
    {
        ChangeScore(_score - 1);
        Show();
    }

    private void ChangeScore(int newValue)
    {
        _score = newValue;
        OnScoreChanged?.Invoke(this, new OnScoreChangedEventArgs {Value = _score});
    }

    private static void Show() 
        => Debug.Log($"Score: {_score}");

    public class OnScoreChangedEventArgs: EventArgs
    {
        public int Value;
    }
}