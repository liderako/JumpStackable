using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using CoreGame;
using CoreGame.Managers;
using CoreGame.Utils;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerJumpState : MonoBehaviour, IState, IEnabledState
{
    [SerializeField] private float _jumpForceZ;
    [SerializeField] private float _jumpForceY;
    private bool _isStateActive;
    private bool _isFinishJumps;
    
    public void Enable()
    {
        _isStateActive = true;
        GetComponent<Animator>().applyRootMotion = false;
        Jump();
        GetComponent<Animator>().SetBool("Flip", true);
        GetComponent<TrailRenderer>().emitting = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ |
                                                RigidbodyConstraints.FreezeRotationZ |
                                                RigidbodyConstraints.FreezeRotationY |
                                                RigidbodyConstraints.FreezeRotationX;
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void Disable()
    {
        if (!_isStateActive)
        {
            return;
        }
        GetComponent<TrailRenderer>().emitting = false;
        _isStateActive = false;
        GetComponent<Animator>().SetBool("Flip", false);
        GetComponent<Animator>().applyRootMotion = true;
        transform.rotation = Quaternion.Euler(0, 90, 0);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ |
                                                RigidbodyConstraints.FreezeRotationZ |
                                                RigidbodyConstraints.FreezePositionX |
                                                RigidbodyConstraints.FreezeRotationY |
                                                RigidbodyConstraints.FreezeRotationX;
        GetComponent<IStatableObject>().ChangeState((IState)GetComponent<IMoveableState>());
        ((IEnabledState)GetComponent<IMoveableState>()).Enable();
    }

    public void UpdateState()
    {

    }

    public void Jump()
    {
        if (_isFinishJumps)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1 * _jumpForceZ / 6, 1f * _jumpForceY / 3, 0), ForceMode.Impulse);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(1 * _jumpForceZ, 1f * _jumpForceY, 0), ForceMode.Impulse);   
        }
    }

    public void LastJumps()
    {
        _isFinishJumps = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.ground && _isStateActive)
        {
            Disable();
        }
    }
}
