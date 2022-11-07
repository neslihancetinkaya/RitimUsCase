using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.EventSystem;
using Utils.RefValues;

namespace BrickBreaker.Scripts
{
    public class GameController : MonoBehaviour
    {
        private bool _isLevelEnd;
        [SerializeField] private IntRef BrickCount;
        [SerializeField] private GameEvent LevelCompleted;
        [SerializeField] private String SceneName = "BrickBreaker";

        private void Awake()
        {
            BrickCount.Value = 0;
        }

        private void Update()
        {
            if (_isLevelEnd)
                return;
            if (BrickCount.Value <= 0)
            {
                _isLevelEnd = true;
                LevelCompleted.Raise();
            }
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}