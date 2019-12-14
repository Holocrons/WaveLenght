using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    private int t = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        if (t == 250) {
            transform.position = new Vector3(Random.Range(-66, 104), Random.Range(-73, 35), transform.position.z);
            t = 0;
        }
    }
}
