using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    
    private float _pathLen;
    private float _currentDistance;
    private bool _finish;

    private void Start()
    {
        _pathLen = Vector3.Distance(_startPosition.position, _endPosition.position);
    }
    
    private void FixedUpdate()
    {
        if (_player.position.x > _endPosition.position.x)
        {
            _progressBar.fillAmount = 1;
            return;
        }
        _currentDistance = _pathLen - Vector3.Distance(_endPosition.position, _player.position);
        _progressBar.fillAmount = _currentDistance / _pathLen;
    }
}
