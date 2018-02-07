using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    public GameObject ballObject;
    public CatControl catControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1) {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Vector3 pos = touch.position;
                pos.z = Camera.main.nearClipPlane * 2.0f;
                var position = Camera.main.ScreenToWorldPoint (pos);
                Instantiate (ballObject, position, Quaternion.identity);
            }
        }
	}
}
