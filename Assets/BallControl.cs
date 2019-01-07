using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallControl : ControlAbstract {
    public GameObject ballObject;
    public CatControl catControl;

	// Use this for initialization
	void Start () {
        useTouchPad = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsControllable && Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Vector3 pos = touch.position;
                pos.z = Camera.main.nearClipPlane * 2.0f;
                Ray ray = Camera.main.ScreenPointToRay(pos);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit) == false || hit.rigidbody == null) {
                    var position = Camera.main.ScreenToWorldPoint(pos);
                    GameObject obj = Instantiate(ballObject, position, Quaternion.identity);
                    obj.GetComponent<BallOperation>().catControl = catControl;
                }
            }
        }
	}
}
