using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class FoodControl : ControlAbstract {
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
        CatPreferences.SaveLastFeedTime ();
    }

    protected override bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
    {
        if (hitTransform == null) {
            return false;
        }
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
}
