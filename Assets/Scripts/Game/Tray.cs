using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SignSine.GoofyWaiter
{
    public class Tray : MonoBehaviour
    {
        [SerializeField] private List<Transform> _gizmoPosition;
        [SerializeField] private List<Jumper> _jumpers;
        // [SerializeField] private ParticleSystem _ps;

        public bool SetJumper(Jumper jumper)
        {
            if (_jumpers.Count >= _gizmoPosition.Count)
            {
                GameObject go = Instantiate(new GameObject(), _gizmoPosition[0].transform);
                go.transform.parent = _gizmoPosition[0].parent;
                go.transform.localPosition = _gizmoPosition[_gizmoPosition.Count - 1].localPosition;
                go.transform.localRotation = Quaternion.Euler(0,0,0);
                go.transform.localScale = new Vector3(1, 1,1);
                go.transform.localPosition = new Vector3(go.transform.localPosition.x - 0.04f, go.transform.localPosition.y, go.transform.localPosition.z);
                _gizmoPosition.Add(go.transform);
            }
            // jumper.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            jumper.gameObject.GetComponent<Collider>().enabled = false;
            jumper.transform.parent = _gizmoPosition[_jumpers.Count].transform;
            jumper.transform.position = _gizmoPosition[_jumpers.Count].position;
            jumper.transform.localRotation = Quaternion.Euler(0,90, 0);
            jumper.transform.localScale = new Vector3(1, 1,1);
            jumper.transform.localPosition = Vector3.zero;
            _jumpers.Add(jumper);
            return true;
        }

        // public void DestroyPlates()
        // {
        //     for (int i = 0; i < plates.Count; i++)
        //     {
        //         Destroy(plates[i].gameObject);
        //     }
        //     plates.Clear();
        // }

        public List<Jumper> GetJumpers()
        {
            return _jumpers;
        }

        public Jumper GetLastJumper()
        {
            if (_jumpers.Count == 0)
                return null;
            Jumper j = _jumpers[_jumpers.Count-1];
            _jumpers.RemoveAt(_jumpers.Count-1);
            return j;
        }
    }
}
