using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowTpMarker : MonoBehaviour
{

    [SerializeField] private InputActionReference activateReferenceLeft;
    [SerializeField] private InputActionReference activateReferenceRight;

    private GameObject[] tpMarkers;
    void Awake()
    {
        tpMarkers = GameObject.FindGameObjectsWithTag("TeleportMarker");

    }

    private void LateUpdate()
    {
        if (activateReferenceLeft.action.IsPressed() == true)
        {
            setMarkerVis(true);
        }
        else if (activateReferenceRight.action.IsPressed() == true)
        {
            setMarkerVis(true);
        }
        else
        {
            setMarkerVis(false);
        }
    }

    void setMarkerVis(bool vis)
    {
        foreach (GameObject o in tpMarkers)
        {
            o.SetActive(vis);
        }
    }
}
