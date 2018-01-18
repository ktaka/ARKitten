using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CatControl : MonoBehaviour {
    public Transform hitTransform;
    private Quaternion rotateFrom;
    private Quaternion rotateTo;
    private float rotateDelta = 0.0f;
    private const float rotateDuration = 3.0f;
    private const float delayTime = 3.0f;

    Vector3 GetLookVector () {
        Vector3 lookVector = Camera.main.transform.position - hitTransform.transform.position;
        lookVector.y = 0.0f; // Y         
        lookVector.Normalize ();
        return lookVector;
    }

    bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
    {
        List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
        if (hitResults.Count > 0) {
            foreach (var hitResult in hitResults) {
                Debug.Log ("Got hit!");
                ResetRotateAnim ();
                hitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                hitTransform.rotation = Quaternion.LookRotation (GetLookVector());
                return true;
            }
        }
        return false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && hitTransform != null) {
            var touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
                var screenPosition = Camera.main.ScreenToViewportPoint (touch.position);
                ARPoint point = new ARPoint {
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

                foreach (ARHitTestResultType resultType in resultTypes) {
                    if (HitTestWithResultType (point, resultType)) {
                        return;
                    }
                }
            }
        } else {
            if (rotateDelta <= 0.0f) {
                ResetRotateAnim ();
                CheckObjDirection ();
            } else {
                RotateToCamera ();
                rotateDelta -= Time.deltaTime;
            }
        }
	}

    void ResetRotateAnim () {
        rotateDelta = 0.0f;
    }

    void CheckObjDirection () {
        Vector3 objToCameraVec = GetLookVector ();
        if (objToCameraVec == Vector3.zero) {
            objToCameraVec = -Camera.main.transform.forward;
        }
        Vector3 objDirVector = hitTransform.forward;
        float dot = Vector3.Dot (objToCameraVec, objDirVector);
        if (dot <= 0.5f) {
            rotateFrom = hitTransform.transform.rotation;
            rotateTo = Quaternion.LookRotation (objToCameraVec, Vector3.up);
            rotateDelta = rotateDuration + delayTime;
        }
    }

    void RotateToCamera() {
        if (rotateDelta <= rotateDuration) {
            float t = 1.0f - (rotateDelta / rotateDuration); hitTransform.transform.rotation =
                Quaternion.Slerp(rotateFrom, rotateTo, t);
        }
    }
}
