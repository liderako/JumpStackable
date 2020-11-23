using System.Collections;
using System.Collections.Generic;
using CoreGame.Utils;
using UnityEngine;

namespace CoreGame.AliveObject
{
    public class Enemy : MonoBehaviour, IAliveObject, IStatableObject, IDamagable
    {
        public IHealthSystem HealthSystem {get; protected set; }
        protected IState _mainState;
        private const int _defaultHp = 100;

        protected virtual void Start()
        {
            HealthSystem = GetComponent<IHealthSystem>();
            InitData();
        }

        protected virtual void FixedUpdate()
        {
            if (_mainState != null)
            {
                _mainState.UpdateState();
            }
        }

        public virtual void ChangeState(IState state)
        {
            _mainState = state;
        }

        public virtual void ReceiveHit(int damage)
        {
            HealthSystem.SubstractHealth(damage);
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }

        protected virtual void InitData()
        {
            HealthSystem.Init(_defaultHp); // add hp
        }

        public int GetHp()
        {
            return _defaultHp;
        }
    }
}
