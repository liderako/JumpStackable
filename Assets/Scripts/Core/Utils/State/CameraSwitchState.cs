using System.Collections;
using System.Collections.Generic;
using CoreGame.Managers;
using UnityEngine;
using CoreGame.Utils;

namespace CoreGame.Utils
{
    public class CameraSwitchState : IState
    {
        private Transform _ownerTransform;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private float _speedMove = 0;
        private float _speedRotate = 0;

        public CameraSwitchState(Transform ownerTransform, Vector3 targetPosition, Quaternion targetRotation)
        {
            _ownerTransform = ownerTransform;
            _targetPosition = targetPosition;
            _targetRotation = targetRotation;
        }
        
        public CameraSwitchState(Transform ownerTransform, Vector3 targetPosition, Quaternion targetRotation, float speedRotate, float speedMove)
        {
            _ownerTransform = ownerTransform;
            _targetPosition = targetPosition;
            _targetRotation = targetRotation;
            _speedMove = speedMove;
            _speedRotate = speedRotate;
        }

        public void UpdateState()
        {
            _ownerTransform.position = Vector3.MoveTowards(_ownerTransform.position, _targetPosition, _speedMove * Time.deltaTime);
            _ownerTransform.rotation = Quaternion.RotateTowards(_ownerTransform.rotation, _targetRotation,
                _speedRotate * Time.deltaTime);
        }
    }
}