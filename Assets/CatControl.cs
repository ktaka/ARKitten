using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class CatControl : ControlAbstract, IDragHandler {
    private Quaternion rotateFrom;
    private Quaternion rotateTo;
    private float rotateDelta = 0.0f;
    private const float rotateDuration = 3.0f;
    private const float delayTime = 3.0f;
    private bool isMoving = false;
    private float arrivalTime = 0;
    private float speed;
    private Rigidbody rb;
    private int strokingNum = 0;
    public int strokingThreshold = 50;

    public void OnDrag (PointerEventData eventData) {
        strokingNum++;
        if (strokingNum > strokingThreshold) {
            GetComponent<Animation> ().Play ("IdleSit");
            GetComponent<Animation> ().PlayQueued ("Idle");
            strokingNum = 0;
            CatPreferences.addStrokingNum ();
        }
    }

    Vector3 GetLookVector () {
        Vector3 lookVector = Camera.main.transform.position - rb.position;
        lookVector.y = 0.0f; // Y         
        lookVector.Normalize ();
        return lookVector;
    }

    protected override bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
    {
        List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
        if (hitResults.Count > 0) {
            foreach (var hitResult in hitResults) {
                Debug.Log ("Got hit!");
                ResetRotateAnim ();
                rb.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                rb.rotation = Quaternion.LookRotation (GetLookVector());
                return true;
            }
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        if (!isMoving) {
            if (rotateDelta <= 0.0f) {
                CheckObjDirection ();
            } else {
                RotateToCamera ();
                rotateDelta -= Time.deltaTime;
                if (rotateDelta <= 0.0f) {
                    ResetRotateAnim ();
                }
            }
        }
    }

    void ResetRotateAnim () {
        rotateDelta = 0.0f;
        GetComponent<Animation> ().Play ("Idle");
    }

    bool checkTemper() {
        if (((int)CatPreferences.ElapsedSecondsFromLastCared) % 20 == 0) {
            GetComponent<Animation> ().Play ("Ithcing");
            GetComponent<Animation> ().PlayQueued ("Idle");
            return false;
        }
        if (CatPreferences.IsGoodTemper() && !isMoving) {
            Vector3 cameraPos = Camera.main.transform.position;
            cameraPos.y = rb.transform.position.y;
            float dist = (cameraPos - rb.transform.position).magnitude;
            if (dist > 1.0f) {
                MoveTo (Camera.main.transform.position, -0.5f);
            }
            return false;
        }
        return true;
    }

    void CheckObjDirection () {
        if (checkTemper()) {
            return;
        }
        Vector3 objToCameraVec = GetLookVector ();
        if (objToCameraVec == Vector3.zero) {
            objToCameraVec = -Camera.main.transform.forward;
        }
        Vector3 objDirVector = rb.transform.forward;
        float dot = Vector3.Dot (objToCameraVec, objDirVector);
        if (dot <= 0.5f) {
            rotateFrom = rb.rotation;
            rotateTo = Quaternion.LookRotation (objToCameraVec, Vector3.up);
            rotateDelta = rotateDuration + delayTime;
        }
    }

    void RotateToCamera() {
        if (rotateDelta <= rotateDuration) {
            GetComponent<Animation> ().Play ("Walk");
            float t = 1.0f - (rotateDelta / rotateDuration);
            rb.rotation =
                Quaternion.Slerp(rotateFrom, rotateTo, t);
        }
    }

    void FixedUpdate() {
        if (arrivalTime > 0.0f) {
            arrivalTime -= Time.deltaTime;
            if (arrivalTime < Mathf.Epsilon) {
                ResetRotateAnim ();
                GetComponent<Animation> ().Play ("Meow");
                GetComponent<Animation> ().PlayQueued ("Idle");
                isMoving = false;
            }
            rb.MovePosition (rb.position + transform.forward * speed * Time.deltaTime); }
    }

    public void MoveTo(Vector3 pos, float offset = 0.0f) {
        Vector3 planePos = pos;
        planePos.y = rb.transform.position.y;
        rb.transform.LookAt (planePos);
        Vector3 distanceVec = pos - transform.position;
        float distance = distanceVec.magnitude + offset;
        isMoving = true;
        if (distance > 1.0f) {
            speed = 0.6f;
            GetComponent<Animation> ().Play ("Run");
        } else {
            speed = 0.2f;
            GetComponent<Animation> ().Play ("Walk");
        }
        arrivalTime = distance / speed;
    }
}
