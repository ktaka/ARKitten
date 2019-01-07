using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownCallback : MonoBehaviour {
    public GameObject touchPad;
    TouchControl touchControl;
    public ControlAbstract[] controllableObjects;

    void Start()
    {
        touchControl = touchPad.GetComponent<TouchControl>();
        if (controllableObjects.Length > 0) {
            controllableObjects[0].IsControllable = true;
            touchControl.ControllableObject = controllableObjects[0];
        }
    }

    public void OnValueChanged(int result) {
        foreach (ControlAbstract c in controllableObjects) {
            c.IsControllable = false;
        }
        ControlAbstract controllableObject = controllableObjects[result];
        controllableObject.IsControllable = true;
        touchControl.ControllableObject = controllableObject;
        if (controllableObject.UseTouchPad)
        {
            touchPad.SetActive(true);
        } else {
            touchPad.SetActive(false);
        }
    }
}
