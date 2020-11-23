using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Utils;

namespace CoreGame.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public delegate void GameEvent();
        public event GameEvent OnFinishEvent;
        public event GameEvent OnGameOverEvent;
        public event GameEvent OnGameEvent;
        public event GameEvent OnFight;
        public GameState state;

        public GameSettings settings;
        [SerializeField] private int _currentLvl;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
            ChangeState(GameState.MENU_TO_GAME);
        }

        private void InitializeLevel()
        {
/*#if true
            int level = 1;
            _currentLvl = level;
            _dataLvl[level].SetActive(true);
            return;
#endif*/
            //if (PlayerPrefs.GetInt("lvl", 0) == 0)
            //{
            //    PlayerPrefs.SetInt("lvl", 0);
            //    _currentLvl = 0;
            //}
            //for (int i = 0; i < _dataLvl.Count; i++)
            //{
            //    _dataLvl[i].SetActive(false);
            //}
            //_currentLvl = PlayerPrefs.GetInt("lvl");
            //if (_currentLvl < _dataLvl.Count)
            //{
            //    _dataLvl[_currentLvl].SetActive(true);
            //}
            //else
            //{
            //    int loading;
            //    do
            //    {
            //        loading = Random.Range(0, _dataLvl.Count);
            //        break;
            //    }
            //    while (loading == _currentLvl);
            //    _dataLvl[loading].SetActive(true);
            //} 
        }
        
        public void ChangeState(GameState newState)
        {
            state = newState;
            if (newState == GameState.CONNECTION)
            {
            }
            else if (newState == GameState.INITIAL)
            {
            }
            else if (newState == GameState.IN_GAME)
            {
                CallGameEvent();
            }
            else if (newState == GameState.FINISH)
            {
                CallFinishEvent();
            }
            else if (newState == GameState.GAME_OVER)
            {
                CallGameOverEvent();
            }
            else if (newState == GameState.MENU_TO_GAME)
            {
            }
            else if (newState == GameState.READY_TO_GO)
            {
            }
        }

        private void CallFinishEvent()
        {
            _currentLvl += 1;
            PlayerPrefs.SetInt("lvl", _currentLvl);
            if (OnFinishEvent != null)
            {
                OnFinishEvent();
                // TinySauce.OnGameFinished(_currentLvl.ToString(), true, 0);
                Debug.Log("Finish");
            }
            else
            {
                Debug.LogError("OnFinishEvent doesn't have listeners");
            }
        }

        private void CallGameEvent()
        {
            if (OnGameEvent != null)
            {
                // TinySauce.OnGameStarted(_currentLvl.ToString());
                Debug.Log("Game start");
                OnGameEvent();
            }
            else
            {
                Debug.LogError("OnGameEvent doesn't have listeners");
            }
        }
        
        private void CallGameOverEvent()
        {
            if (OnGameOverEvent != null)
            {
                // TinySauce.OnGameFinished(_currentLvl.ToString(), false, 0);
                Debug.Log("Game Over");
                OnGameOverEvent();
            }
            else
            {
                Debug.LogError("OnGameEvent doesn't have listeners");
            }
        }

        public int GetCurrentLvl()
        {
            return _currentLvl;
        }

        public void CallFightEvent()
        {
            if (OnFight == null)
            {
                Debug.LogError("Call fight event doesn't have listeners");
                return;
            }
            OnFight();
        }
    }
}
