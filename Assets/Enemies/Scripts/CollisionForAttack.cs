using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForAttack : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth stat = collision.gameObject.GetComponent<PlayerHealth>();
            if (stat) {
                stat.TakeDamage(1);
                print("player took damage");
            }
        }
    }
}
