using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slipery : MonoBehaviour
{

    public float speed = 10;
    public GameObject player;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            player.transform.position = player.transform.position + new Vector3(speed, 0, 0);
        }
    }

}
