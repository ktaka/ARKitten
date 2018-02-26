using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class FoodControl : MonoBehaviour {
    public Transform hitTransform;
    public CatControl catControl;

    public void Show () {
        GetComponent<Renderer> ().enabled = true;
    }

    public void Hide () {
        GetComponent<Renderer> ().enabled = false;
    }

    void OnTriggerEnter(Collider co) {
        Invoke ("Hide", 2.0f);
    }

    bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
    {
        List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
        if (hitResults.Count > 0) {
            foreach (var hitResult in hitResults) {
                hitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                hitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
                catControl.MoveTo (hitTransform.position, -0.15f);
                Show ();
                return true;
            }
        }
        return false;
    }

	// Use this for initialization
    void Start () {
        Hide ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount == 1 && hitTransform != null)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                ARPoint point = new ARPoint {
                    x = screenPosition.x,
                    y = screenPosition.y
                };

                // prioritize reults types
                ARHitTestResultType[] resultTypes = {
                    ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                }; 

                foreach (ARHitTestResultType resultType in resultTypes)
                {
                    if (HitTestWithResultType (point, resultType))
                    {
                        return;
                    }
                }
            }
        }
    }
}
