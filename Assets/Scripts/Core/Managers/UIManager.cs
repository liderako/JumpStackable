using System.Collections;
using System.Collections.Generic;
using CoreGame.Utils;
using TMPro;
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
        
        [Header("Finish Jump")]
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Transform _player;
        [SerializeField] private Transform _finishPoint;
        
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

        public void Update()
        {
            if (_text.gameObject.activeSelf)
            {
                _text.text = "Distance: " + Mathf.Round(Vector3.Distance(new Vector3(_player.position.x,0,0), new Vector3(_finishPoint.position.x, 0, 0)));
            }
        }

        public void FinalJump()
        {
            _text.gameObject.SetActive(true);
        }
    }
}