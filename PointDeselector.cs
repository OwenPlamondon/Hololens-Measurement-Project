using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDeselector : MonoBehaviour, IInputClickHandler
{

	[SerializeField]
	private GameObject _pointA;
    [SerializeField]
    private PointA _pointAScript;
    [SerializeField]
    private GameObject _pointB;
    [SerializeField]
    private PointA _pointBScript;
    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
	{
        _pointA.transform.parent = null;
        _pointAScript._following = false;
        _pointB.transform.parent = null;
        _pointBScript._following = false;
        this.gameObject.SetActive(false);
    }

}
