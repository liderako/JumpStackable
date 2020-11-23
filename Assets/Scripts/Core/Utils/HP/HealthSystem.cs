using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Utils;

namespace CoreGame.Hp
{
    /*
    ** Work with only IAliveObject
    */
    public class HealthSystem : MonoBehaviour, IHealthSystem
    {
        [Header("Health Settings")]
        [SerializeField] protected int _maxHp;
        [SerializeField] protected int _currentHp;
        private IAliveObject _owner;
        public void Init(int maxHp)
        {
            _maxHp = maxHp;
            _currentHp = _maxHp;
            _owner = GetComponent<IAliveObject>();
#if UNITY_EDITOR
            if (_owner == null)
            {
                Debug.LogError(gameObject.name + " doesn't have IAliveObject component. Please add this component.");
            }
#endif
        }

        public virtual void AddHealth(int amount)
        {
            _currentHp = Mathf.Clamp(_currentHp += amount, 0, _maxHp);
        }

        public virtual void SubstractHealth(int damage)
        {
            _currentHp = Mathf.Clamp(_currentHp -= damage, 0, _maxHp);
            if (isDead())
            {
                _owner.Death();
            }
        }

        public bool isDead()
        {
            return _currentHp == 0;
        }
    }
}
