using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    ControlAbstract controllableObject;
    bool isDragging;
    bool isBegan;

    public ControlAbstract ControllableObject {
        get {
            return controllableObject;
        }
        set {
            controllableObject = value;
        }
    }

	// Use this for initialization
	void Start () {
        isDragging = false;
        isBegan = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                if (controllableObject != null)
                {
                    var touch = Input.GetTouch(0);
                    if (isBegan)
                    {
                        controllableObject.OnTouchBegan(touch);
                        isBegan = false;
                    } else if (touch.phase == TouchPhase.Moved) {
                        controllableObject.OnTouchMoved(touch);
                    }
                }
            }
        }
	}

    public void OnPointerDown(PointerEventData data)
    {
        isDragging = true;
        isBegan = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isDragging = false;
    }
}
