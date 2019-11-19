using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showPlatform : MonoBehaviour
{
    GameObject tmp = null;
    bool isctive = false;

    void Update()
    {
        if (tmp == null)
        {
            Debug.Log("courge");
            isctive = false;
        }
        GetComponent<MeshRenderer>().enabled = isctive;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("INIT");
        if (other.tag == "blue")
        {
            isctive = true;
            tmp = other.gameObject;
        }
    }
}
