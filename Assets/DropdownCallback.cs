using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownCallback : MonoBehaviour {
    public ControlAbstract[] controllableObjects;

    public void OnValueChanged(int result) {
        foreach (ControlAbstract c in controllableObjects) {
            c.IsControllable = false;
        }
        controllableObjects [result].IsControllable = true;
    }
}
