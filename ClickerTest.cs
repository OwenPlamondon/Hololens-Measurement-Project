using HoloToolkit.Unity.InputModule;
using System.Collections;
using UnityEngine;


public class ClickerTest : MonoBehaviour, IInputClickHandler
{
    [SerializeField]
    private GameObject _testCube;
    GameObject targetObject = null;
    UnityEngine.XR.WSA.Input.GestureRecognizer gr = null;
    [SerializeField]
    private GameObject _point;

    // Use this for initialization
    void Start()
    {
        CreateTargetObject();
        //SetupGestureRecognizer();
        MoveTarget(0.5f);
    }

#if UNITY_EDITOR
    void Update()
    {
        MoveTarget(GetMouseInput());
    }
#endif

    void CreateTargetObject()
    {
        targetObject = Instantiate(_point, transform.position, Quaternion.identity);
        targetObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        targetObject.transform.parent = Camera.main.transform;
    }

    void SetupGestureRecognizer()
    {
        gr = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        gr.NavigationUpdatedEvent += NavigationUpdatedEvent;
        gr.StartCapturingGestures();
    }

    float GetMouseInput()
    {
        //return Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        return 0.5f;
    }

    void NavigationUpdatedEvent(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        float t = normalizedOffset.x * 0.5f + 0.5f;
        MoveTarget(t);
    }

    // t must be a value between 0.0 and 1.0
    void MoveTarget(float t)
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(t, 0.5f, 3.0f));
        targetObject.transform.position = pos;
    }

    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        Destroy(_testCube);
    }
}