using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlAbstract : MonoBehaviour {
    public GameObject focusSquare;
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
        set {
            isControllable = value;
            if (focusSquare) {
                focusSquare.SetActive (isControllable);
            }
        }
    }
}
