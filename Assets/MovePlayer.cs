using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private float x = 0;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputCatcher();
        MovementManager();
    }

    void MovementManager()
    {
        transform.Translate(-transform.right * x * Time.deltaTime * speed);
    }

    void InputCatcher()
    {
        if (Input.GetKey(KeyCode.Q))
            x = 1;
        else if (Input.GetKey(KeyCode.D))
            x = -1;
        else
            x = 0;
    }
}
