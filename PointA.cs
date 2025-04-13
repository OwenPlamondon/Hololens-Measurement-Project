using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PointA : MonoBehaviour, IInputClickHandler
{

    [SerializeField]
    private GameObject _localLabel;
    [SerializeField]
	private GameObject _pointB;
	private float _distanceX;
    private float _distanceY;
    private float _distanceZ;
    public float _distance;
    private bool _following = false;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        _distanceX = _pointB.transform.position.x - transform.position.x;
        _distanceY = _pointB.transform.position.y - transform.position.y;
        _distanceZ = _pointB.transform.position.z - transform.position.z;

        _distance = Mathf.Sqrt(Mathf.Sqrt(Mathf.Pow(_distanceX, 2) + Mathf.Pow(_distanceY, 2)) + Mathf.Pow(_distanceZ, 2));
    
        if(_following == true)
        {
            _localLabel.SetActive(true);
        }
        else 
        {
            _localLabel.SetActive(false);
        }
    }

    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        if(_following == false)
        {
            this.transform.parent = GameObject.Find("MixedRealityCamera").transform;
            _following = true;
        }
        else
        {
            this.transform.parent = null;
            _following = false;
        }
    }
}
