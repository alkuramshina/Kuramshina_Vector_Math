using System;
using Players;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button quitGameButton;
        
        [SerializeField] private Pausing pausing;

        private const string GameSceneName = "GameScene";

        private void Start()
        {
            pausing.OnGamePaused += OnGamePaused;
            pausing.OnGameResumed += OnGameResumed;

            gameObject.SetActive(false);
        }

        private void Awake()
        {
            resumeButton.onClick.AddListener(pausing.ResumeGame);
            newGameButton.onClick.AddListener(NewGame);
            quitGameButton.onClick.AddListener(Quit);
        }

        private void OnGamePaused(object sender, EventArgs e)
        {
            gameObject.SetActive(true);
        }
        
        private void OnGameResumed(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
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
