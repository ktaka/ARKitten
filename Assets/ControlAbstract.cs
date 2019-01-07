using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.iOS;

public class ControlAbstract : MonoBehaviour {
    public GameObject focusSquare;
    protected bool isControllable;
    protected bool useTouchPad = true;

    public bool UseTouchPad {
        get { return useTouchPad; }
        set { useTouchPad = value; }
    }

    public bool IsControllable {
        get {
            return isControllable;
        }
        set {
            isControllable = value;
            if (focusSquare) {
                focusSquare.SetActive (isControllable);
            }
        }
    }

    public virtual void OnTouchBegan(Touch touch)
    {
        OnTouch(touch);
    }

    public virtual void OnTouchMoved(Touch touch)
    {
        OnTouch(touch);
    }

    protected void OnTouch(Touch touch) {
        var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
        ARPoint point = new ARPoint
        {
            x = screenPosition.x,
            y = screenPosition.y
        };

        // prioritize reults types
        ARHitTestResultType[] resultTypes = {
                ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                // if you want to use infinite planes use this:
                //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                ARHitTestResultType.ARHitTestResultTypeHorizontalPlane,
                ARHitTestResultType.ARHitTestResultTypeFeaturePoint
            };

        foreach (ARHitTestResultType resultType in resultTypes)
        {
            if (HitTestWithResultType(point, resultType))
            {
                return;
            }
        }
    }

    protected virtual bool HitTestWithResultType(ARPoint point, ARHitTestResultType resultTypes) {
        return false;
    }
}
