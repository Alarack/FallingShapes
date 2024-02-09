using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {


    private Camera cam;

    private Vector2 viewPortPos;
    private Vector2 desiredPosition;


    private void Awake() {
        cam = Camera.main;
        desiredPosition = transform.position;
    }

    private void LateUpdate() {
        Wrap();
    }


    private void Wrap() {

        viewPortPos = cam.WorldToViewportPoint(transform.position);

        desiredPosition = transform.position;

        if(viewPortPos.x > 1f) {

            float xPos = cam.ViewportToWorldPoint(Vector2.zero).x;
            float yPos = transform.position.y;
            
            desiredPosition = new Vector2(xPos, yPos);
        }

        if(viewPortPos.x < 0f) {

            float xPos = cam.ViewportToWorldPoint(Vector2.one).x;
            float yPos = transform.position.y;


            desiredPosition = new Vector2 (xPos, yPos);
        }

        transform.position = desiredPosition;

    }

}
