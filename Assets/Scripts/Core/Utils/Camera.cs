using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using CoreGame.Managers;
using CoreGame.Utils.State;

namespace CoreGame.Utils
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private CameraMoveState _cameraMoveState;
        private IState _mainState;
        private Transform _currentTransform;

        private void Awake()
        {
            _cameraMoveState = new CameraMoveState(_target, transform);
            ChangeState(_cameraMoveState);
        }

        private void LateUpdate()
        {
            if (_mainState != null)
            {
                _mainState.UpdateState();
            }
        }

        public void ChangeState(IState state)
        {
            _mainState = state;
        }
    }
}
