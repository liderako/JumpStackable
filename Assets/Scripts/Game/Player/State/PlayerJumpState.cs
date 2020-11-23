using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using CoreGame;
using CoreGame.Utils;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerJumpState : MonoBehaviour, IState, IEnabledState
{
    [SerializeField] private bool _isStateActive;
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
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(new Vector3(0.2f, 1f, 0) * 60, ForceMode.Impulse);
        //transform.DOJump(transform.position + new Vector3(1, 0, 0) * 20, 15, 1, 1f, false);
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.layer == Layers.ground)
    //     {
    //         Disable();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.ground && _isStateActive)
        {
            Disable();
        }
    }
}
