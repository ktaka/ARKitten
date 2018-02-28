using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlAbstract : MonoBehaviour {
    protected bool isControllable;

    public bool IsControllable {
        get {
            if (isControllable) {
                if (EventSystem.current.currentSelectedGameObject) {
                    return false;
                }
            }
            return isControllable;
        }
        set { isControllable = value; }
    }
}
