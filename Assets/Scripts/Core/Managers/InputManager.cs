using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Utils;
using UnityEngine.SceneManagement;

//using UnityEditor.Experimental.GraphView;
//using DG.Tweening;

namespace CoreGame.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        public delegate void TouchEvent();
        public event TouchEvent OnTouch;
        public event TouchEvent OffTouch;

        public delegate void MoveEvent(Vector2 direction);
        public event MoveEvent OnMove;

        private bool _controlEnable;
        private Vector2 _beginPosition;
        private Vector2 _tmpPosition;

        [SerializeField] private TouchState _stateTouch;
        private Vector2 _direction;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            _stateTouch = TouchState.ENDED;
            _controlEnable = true;
        }

        private void FixedUpdate()
        {
        }
        public void Update()
        {
            if (GameManager.Instance.state == GameState.IN_GAME)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (OnTouch == null)
                    {
                        return;
                    }
                    OnTouch();
                }
                // if (OnTouch == null || _controlEnable == false)
                // {
                //     return;
                // }
                // if (Input.GetMouseButtonDown(0))
                // {
                //     Debug.Log("Touch");
                //     OnTouch();
                //     _stateTouch = TouchState.BEGAN;
                //     _beginPosition = new Vector2(Input.mousePosition.x, 0);
                //     _direction = Vector2.zero;
                // }
                // if (OffTouch == null)
                // {
                //     return;
                // }
                // if (Input.GetMouseButtonUp(0))
                // {
                //     OffTouch();
                //     _stateTouch = TouchState.ENDED;
                // }
                // if (Input.GetMouseButton(0))
                // {
                //     InputMoveControll();
                // }
            }
            else if (GameManager.Instance.state == GameState.MENU_TO_GAME)
            {
                // if (Input.GetMouseButtonDown(0))
                // {
                //     GameManager.Instance.ChangeState(GameState.IN_GAME);
                // }
            }
            else if (GameManager.Instance.state == GameState.FINISH || GameManager.Instance.state == GameState.GAME_OVER)
            {
                // if (Input.GetMouseButtonDown(0))
                // {
                //     Destroy(GameManager.Instance.gameObject);
                //     // GameManager.Instance.ChangeState(GameState.MENU_TO_GAME);
                //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //     // GameManager.Instance.ChangeState(GameState.MENU_TO_GAME);
                // }
            }
        }


        private float cencetive = 11.5f;
        
        private void InputMoveControll()
        {
            if (_stateTouch == TouchState.BEGAN)
            {
                _tmpPosition = new Vector2(Input.mousePosition.x, 0);
                if (Vector2.Distance(_tmpPosition, _beginPosition) > 0.0001f)
                {
                    //_direction = (_tmpPosition - _beginPosition).normalized;
                    //_beginPosition = _tmpPosition;
                    if (OnMove != null)
                    {
                        //OnMove(_direction);
                        OnMove((UnityEngine.Camera.main.ScreenToViewportPoint(_tmpPosition) - UnityEngine.Camera.main.ScreenToViewportPoint(_beginPosition)) * cencetive);
                        _beginPosition = _tmpPosition;
                    }
                }
                else
                {
                    if (OnMove != null)
                    {
                        OnMove(Vector2.zero);
                    }
                }
            }
        }
    }
}