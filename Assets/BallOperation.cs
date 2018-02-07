using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOperation : MonoBehaviour {
    public CatControl catControl;
    private int collisionCount = 0;
    private float yPosition;

    void OnCollisionEnter(Collision co) {
        collisionCount++;
        if (collisionCount > 1) {
            catControl.MoveTo (transform.position);
            collisionCount = 0;
        }
        yPosition = co.transform.position.y;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
