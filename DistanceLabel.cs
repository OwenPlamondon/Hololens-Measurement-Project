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

        _text.text = (_pointAScript._distance.ToString("F2")) + " meters";

        Vector3 directionToCamera = _camera.transform.position - transform.position;
        transform.LookAt(transform.position - directionToCamera);
    }
}
