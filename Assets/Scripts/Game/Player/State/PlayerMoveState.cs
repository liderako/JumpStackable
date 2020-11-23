using System.Collections;
using System.Collections.Generic;
using CoreGame;
using CoreGame.Utils;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IState, IEnabledState, IMoveableState
{
    [SerializeField] private float _speed;
    private Vector3 DIRECTION = new Vector3(1, 0, 0);
    private void Start()
    {
    }
    
    public void Enable()
    {
        GetComponent<Animator>().SetBool(Tags.Run, true);
    }

    public void Disable()
    {
        // GetComponent<Animator>().SetBool(Tags.Run, false);
    }

    public void UpdateState()
    {
        Move();
    }

    public void Move()
    {
        transform.position += DIRECTION * Time.deltaTime * _speed;
    }
}
