using System;
using UnityEngine;

namespace Players
{
    public class Pausing: MonoBehaviour
    {
        private PlayerControls _playerControls;

        public event EventHandler OnGamePaused;
        public event EventHandler OnGameResumed;

        private bool _gameIsPaused;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();

            _playerControls.Default.Pause.Enable();
            _playerControls.Default.Pause.performed += _ => ToggleGamePause();

            _gameIsPaused = false;
        }

        private void ToggleGamePause()
        {
            _gameIsPaused = !_gameIsPaused;

            if (_gameIsPaused)
            {
                Time.timeScale = 0f;
                OnGamePaused?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Time.timeScale = 1f;
                OnGameResumed?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ResumeGame()
        {
            if (!_gameIsPaused)
            {
                return;
            }
            
            ToggleGamePause();
        }

        private void OnDestroy()
        {
            _playerControls.Default.Pause.Disable();
            _playerControls.Disable();
        }
    }
}