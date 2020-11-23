using System.Collections;
using System.Collections.Generic;
using CoreGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGame.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _finishMenu;
        [SerializeField] private GameObject _gamePlayMenu;
        [SerializeField] private RawImage  _finishCircleOnProgressBar;
        [SerializeField] private Color _finishColorOnProgressBar;
        private void Start()
        {
            GameManager.Instance.OnGameEvent += OnHandleGame;
            GameManager.Instance.OnGameOverEvent += OnHandleGameOver;
            GameManager.Instance.OnFinishEvent += OnHandleFinish;
        }

        private void OnHandleGame()
        {
            _menu.SetActive(false);
            _gamePlayMenu.SetActive(true);
        }

        private void OnHandleGameOver()
        {
            _gameOverMenu.SetActive(true);
            _gameOverMenu.GetComponent<UnityEngine.Animation>().Play();
            _gamePlayMenu.SetActive(false);
        }
        
        private void OnHandleFinish()
        {
            _finishMenu.SetActive(true);
            _finishMenu.GetComponent<UnityEngine.Animation>().Play();
            _gamePlayMenu.SetActive(false);
            _finishCircleOnProgressBar.color = _finishColorOnProgressBar;
        }
    }
}