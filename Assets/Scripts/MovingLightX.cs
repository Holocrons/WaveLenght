using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLightX : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0 , 0));
    }
}
