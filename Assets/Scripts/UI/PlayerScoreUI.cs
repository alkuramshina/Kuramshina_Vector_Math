using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerScoreUI : MonoBehaviour
    {
        [SerializeField] private Scorer scorer;
        [SerializeField] private TextMeshProUGUI healthText;

        private void Start()
        {
            scorer.OnScoreChanged += ScorerOnScoreChanged;
        }

        private void ScorerOnScoreChanged(object sender, Scorer.OnScoreChangedEventArgs e)
        {
            healthText.text = e.Value.ToString();
        }
    }
}