using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button quitGameButton;

        private const string GameSceneName = "GameScene";
        
        private void Awake()
        {
            newGameButton.onClick.AddListener(NewGame);
            quitGameButton.onClick.AddListener(Quit);

            Time.timeScale = 1f;
        }

        private void NewGame()
        {
            SceneManager.LoadScene(GameSceneName);
        }
        
        private void Quit()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
