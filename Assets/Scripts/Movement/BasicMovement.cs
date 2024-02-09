using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    [Header("Movement Variables")]
    public float moveSpeed;

    private Vector2 direction;

    public Rigidbody2D MyRigidbody { get; protected set; }


    private void Awake() {
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
    }

    public void GetInput() {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private void Move() {
        Vector2 moveForce = new Vector2(direction.x, 0f) * moveSpeed * Time.fixedDeltaTime;

        MyRigidbody.AddForce(moveForce, ForceMode2D.Force);
    }

}
