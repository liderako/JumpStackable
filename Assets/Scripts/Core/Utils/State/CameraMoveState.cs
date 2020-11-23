using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Utils.State
{
    public class CameraMoveState : IState
    {
        private Vector3 _offset;
        private Transform _ownerTransform;
        private Transform _targetTransform;
        public bool isFast;
        public CameraMoveState(Transform transformTarget, Transform ownerTransform)
        {
            _ownerTransform = ownerTransform;
            _targetTransform = transformTarget;
            _offset = ownerTransform.localPosition - transformTarget.localPosition;
        }

        public void UpdateState()
        {
            // _ownerTransform.localPosition = Vector3.Lerp( _targetTransform.localPosition, _targetTransform.localPosition + _offset, 0.1f);
            _ownerTransform.localPosition = Vector3.Lerp(_ownerTransform.localPosition, _targetTransform.localPosition + _offset, 0.1f);
        }
    }
}