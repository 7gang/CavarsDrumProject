using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorToggle : MonoBehaviour
{
    [SerializeField] private InputActionReference activateReference;


    private bool isEnabled = false;
    private XRRayInteractor rayInteractor;

    private void Awake()
    {
        rayInteractor = this.gameObject.GetComponent<XRRayInteractor>();
    }

    private void OnEnable()
    {
        activateReference.action.started += ToggleRay;
        activateReference.action.canceled += ToggleRay;



    }

    private void OnDisable()
    {
        activateReference.action.started -= ToggleRay;
        activateReference.action.canceled -= ToggleRay;

    }

    private void ToggleRay(InputAction.CallbackContext obj)
    {
        isEnabled = obj.control.IsPressed();
        
    }

    void LateUpdate()
    {
        ApplyStatus();
    }

    private void ApplyStatus()
    {
        if (rayInteractor.enabled != isEnabled)
            rayInteractor.enabled = isEnabled;


    }
    
}
