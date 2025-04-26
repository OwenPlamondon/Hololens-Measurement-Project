using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceLabel : MonoBehaviour
{
    [SerializeField]
    private PointA _pointAScript;
    [SerializeField]
    private GameObject _pointA;
    [SerializeField]
    private GameObject _pointB;
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private TextMesh _text;
    [SerializeField]
    private bool _scalable = false;
    public bool _imperial = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float midpointX = (_pointB.transform.position.x + _pointA.transform.position.x) / 2;
        float midpointY = (_pointB.transform.position.y + 0.1f + _pointA.transform.position.y) / 2;
        float midpointZ = (_pointB.transform.position.z + _pointA.transform.position.z) / 2;

        this.transform.position = new Vector3(midpointX, midpointY, midpointZ);

        if( _scalable == true)
        {
            transform.localScale = new Vector3(0.075f * _pointAScript._distance, 0.075f * _pointAScript._distance, 0.075f * _pointAScript._distance);
        }

        if(_imperial == false)
        {
            _text.text = (_pointAScript._distance.ToString("F2")) + " meters";
        }
        else
        {
            float imperialDistance = _pointAScript._distance * 3.28084f;
            float imperialFeet = Mathf.Floor(imperialDistance);
            float imperialInches = (imperialDistance - imperialFeet) * 12;
            _text.text = (imperialFeet.ToString("F0")) + " ft " + (imperialInches.ToString("F0")) + " in";
        }

            Vector3 directionToCamera = _camera.transform.position - transform.position;
        transform.LookAt(transform.position - directionToCamera);
    }
}
