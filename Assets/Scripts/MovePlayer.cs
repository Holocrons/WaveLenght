using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private float x = 0;
    public float speed = 0;
    public float jumpForce = 0;
    public GameObject lightPrefabs;
    public GameObject lightPrefabs2;
    private bool jump = false;
    private bool inAir = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputCatcher();
    }

    private void FixedUpdate()
    {
        MovementManager();
    }

    void MovementManager()
    {
        transform.Translate(-transform.right * x * Time.deltaTime * speed);
        if (jump == true)
        {
            rb.AddForce(new Vector3(0, jumpForce * Time.deltaTime * 10, 0));
            jump = false;
        }
    }

    void InputCatcher()
    {
        if (Input.GetKey(KeyCode.Q))
            x = 1;
        else if (Input.GetKey(KeyCode.D))
            x = -1;
        else
            x = 0;
        if (Input.GetKeyDown(KeyCode.E))
            Instantiate(lightPrefabs, transform.position, new Quaternion(0, 0, 0, 0));
        if (Input.GetKeyDown(KeyCode.A))
            Instantiate(lightPrefabs2, new Vector3(transform.position.x ,transform.position.y,-20), new Quaternion(0, 0, 0, 0));
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)
            jump = true;
    }
}
