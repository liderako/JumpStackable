using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame;
using CoreGame.Managers;
using CoreGame.Utils;
using SignSine.GoofyWaiter;
using UnityEngine;

public class Player : MonoBehaviour, IStatableObject
{
    private bool _isDead;
    private IState _mainState;
    private IState _subState;
    private IEnabledState[] _enabledStates;
    [SerializeField] private Tray _tray;
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private GameObject _canvasPoint;
    [SerializeField] private List<Behaviour> _list;
    [SerializeField] private GameObject _rootBone;
    [SerializeField] private ParticleSystem _ps;
    private void Awake()
    {
        Collider[] col = _rootBone.GetComponentsInChildren<Collider>();
        foreach (var c in col)
        {
            c.enabled = false;
        }
        Rigidbody[] rbs = _rootBone.GetComponentsInChildren<Rigidbody>();
        foreach (var c in rbs)
        {
            c.isKinematic = true;
        }
    }
    
    private void Start()
    {
        GameManager.Instance.OnGameEvent += OnHandeGame;
    }
    private void Update()
    {
        if (_mainState != null)
        {
            _mainState.UpdateState();
        }

        if (_subState != null)
        {
            _subState.UpdateState();
        }
    }

    public void ChangeState(IState state)
    {
        for (int i = 0; i < _enabledStates.Length; i++)
        {
            _enabledStates[i].Disable();
        }
        _mainState = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Jumper>() != null)
        {
            GameObject go = Instantiate(_pointPrefab, _canvasPoint.transform);
            go.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
            _tray.SetJumper(other.GetComponent<Jumper>());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8) // dead
        {
            _mainState = null;
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].enabled = false;
            }
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            _isDead = true;
            GameManager.Instance.ChangeState(GameState.GAME_OVER);
            Collider[] col = _rootBone.GetComponentsInChildren<Collider>();
            foreach (var c in col)
            {
                c.enabled = true;
            }
            Rigidbody[] rbs = _rootBone.GetComponentsInChildren<Rigidbody>();
            foreach (var c in rbs)
            {
                c.isKinematic = false;
            }
            _rootBone.GetComponentInChildren<Rigidbody>().AddForce(-transform.forward * 70, ForceMode.Impulse);
        }
        else if (other.gameObject.layer == 9) // finish
        {
            _mainState = null;
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].enabled = false;
            }
            GetComponent<TrailRenderer>().enabled = false;
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Animator>().SetBool("Dance", true);
            GetComponent<Animator>().SetBool("Flip", false);
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Fly", false);
            GetComponent<Animator>().enabled = true;
            _ps.Play(true);
            GameManager.Instance.ChangeState(GameState.FINISH);
        }
        else if (other.gameObject.layer == 11) // finish
        {
            _mainState = GetComponent<PlayerJumpState>();
            GetComponent<PlayerJumpState>().Enable();
        }
    }

    // events
    private void OnHandeGame()
    {
        IEnabledState[] enabledStates = gameObject.GetComponents<IEnabledState>();
        _enabledStates = new IEnabledState[enabledStates.Length];
        for (int i = 0; i < enabledStates.Length; i++)
        {
            _enabledStates[i] = enabledStates[i];
        }
        ChangeState((IState)gameObject.GetComponent<IMoveableState>());
        ((IEnabledState)gameObject.GetComponent<IMoveableState>()).Enable();
        InputManager.Instance.OnTouch += OnTouchHandle;
    }

    private void OnTouchHandle()
    {
        if (_isDead)
        {
            return;
        }
        Jumper jumper = _tray.GetLastJumper();
        if (jumper == null)
            return;
        GameObject go = jumper.gameObject;
        _mainState = GetComponent<PlayerJumpState>();
        GetComponent<PlayerJumpState>().Enable();
        go.transform.position = transform.position;
        go.transform.parent = transform.parent;
    }
}
