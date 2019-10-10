using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingLight : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction = new Vector3(0, 0, -1);
    private Light lightRef;

    void Start()
    {
        lightRef = GetComponent<Light>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        lightRef.intensity = transform.position.z / -30;
    }
}
