using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	[SerializeField]
	private GameObject _target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 directionToTarget = _target.transform.position - transform.position;
        transform.LookAt(transform.position - directionToTarget);
    }
}
