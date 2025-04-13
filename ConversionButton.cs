using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversionButton : MonoBehaviour, IInputClickHandler
{
    [SerializeField]
    private DistanceLabel _distanceLabel;
    [SerializeField]
	private DistanceLabel _pointA;
	[SerializeField]
	private DistanceLabel _pointB;
	private bool _imperial = false;
	
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
	{
		if(_imperial == false)
		{
			_imperial = true;
			_distanceLabel._imperial = true;
            _pointA._imperial = true;
            _pointB._imperial = true;
        }
		else
		{
			_imperial = false;
            _distanceLabel._imperial = false;
            _pointA._imperial = false;
            _pointB._imperial = false;
        }
	}
}
