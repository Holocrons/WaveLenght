using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Vector3 dir = Vector3.forward;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Enemy"))
        {
            EnemyStat stat = collider.transform.gameObject.GetComponent<EnemyStat>();
            if (stat)
                stat.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
