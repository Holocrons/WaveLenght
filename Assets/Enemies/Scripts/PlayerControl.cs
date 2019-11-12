using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed = 40;
    public float modulo = 15;
    private Rigidbody rigidBody;
    private float x_min;
    private float x_max;
    private float z_min;
    private float z_max;

    void Awake (){
        rigidBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        KeyboardMovement();
        // KeepWithinMinMaxRectangle();
    }

    private void KeyboardMovement (){
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float xSpeed = xMove * speed;
        float ySpeed = yMove * speed;
        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0);
        // Vector3 newVelocity = new Vector3(xSpeed, 0, 0);
        rigidBody.velocity = newVelocity;
        // if (transform.position.x > modulo)
        //     transform.position = new Vector3(transform.position.x % modulo, transform.position.y, transform.position.z);
        // restrict player movement
        // KeepWithinMinMaxRectangle ();
    }

    // private void KeepWithinMinMaxRectangle (){
    //     float x = transform.position.x;
    //     float y = transform.position.y;
    //     float z = transform.position.z;
    //     float clampedX = Mathf.Clamp(x, x_min, x_max);
    //     // float clampedZ = Mathf.Clamp(z, z_min, z_max);
    //     transform.position = new Vector3(clampedX, y, z);
    // }
}