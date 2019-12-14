using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRaycast : MonoBehaviour
{

    private bool hasHit = false;
    public LayerMask lm;
    private RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1, lm) == true)
            hasHit = true;
        else
            hasHit = false;
    }

    public Vector3 GetRayHit()
    {
        if (hasHit == true)
        {
            return hit.transform.position;
        }
        else
            return new Vector3(0, 0, 0); 
    }


    public bool HasHit()
    {
        return (hasHit);
    }
}
