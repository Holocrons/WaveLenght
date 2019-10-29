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
    public int playerNb = 1;
    public List<RuntimeAnimatorController> animList;
    private Animator anim;
    public GameObject GroundCheck;
    private GroundRaycast gc;
    public List<GameObject> followPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gc = GroundCheck.GetComponent<GroundRaycast>();
    }

    private void Update()
    {
        inAir = !gc.HasHit();
        Debug.Log(inAir);
        if (playerNb == 1)
            InputCatcher();
        else if (playerNb == 2)
            InputCatcher2();
        if (x != 0 && inAir == false)
            anim.runtimeAnimatorController = animList[2];
        else if (inAir == false)
            anim.runtimeAnimatorController = animList[0];
        else
            anim.runtimeAnimatorController = animList[1];
        foreach (GameObject obj in followPlayer)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, obj.transform.position.z);
            obj.transform.position = newPos;
        }
        if (x == 1)
            transform.eulerAngles = new Vector3(0, 90, 0);
        else if (x == -1)
            transform.eulerAngles = new Vector3(0, -90, 0);
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

    void InputCatcher2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            x = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            x = -1;
        else
            x = 0;
        if (Input.GetKeyDown(KeyCode.O))
            Instantiate(lightPrefabs, transform.position, new Quaternion(0, 0, 0, 0));
        if (Input.GetKeyDown(KeyCode.P))
            Instantiate(lightPrefabs2, new Vector3(transform.position.x, transform.position.y, -20), new Quaternion(0, 0, 0, 0)).GetComponent<MovingLightX>().dir(transform.eulerAngles.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && inAir == false)
            jump = true;
    }

    void InputCatcher()
    {
        if (Input.GetKey(KeyCode.D))
            x = 1;
        else if (Input.GetKey(KeyCode.Q))
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
