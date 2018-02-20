using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropdownCallback : MonoBehaviour {
    public ControlAbstract[] controllableObjects;

    public void OnValueChanged(int result) {
        controllableObjects [result].setControllable (true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0)) {
            int layer = EventSystem.current.currentSelectedGameObject.layer;
            if (layer == 5) {
                foreach (ControlAbstract c in controllableObjects) {
                    c.setControllable (false);
                }
            }
        }
	}
}
