using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingLight : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction = new Vector3(0, 0, -1);
    private Light lightRef;
    public GameObject ball;
    private float timer = 0;
    private bool goBall = false;
    Vector3 scale = new Vector3(1, 1, 1);


    void Start()
    {
        lightRef = GetComponent<Light>();
    }

    void Update()
    {
        if (transform.position.z > -75)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            lightRef.intensity = transform.position.z / -30;
            timer = Time.time + 0f;
        }
        else if (goBall == true)
        {
            ball.SetActive(true);
            scale += new Vector3(speed / 5 * Time.deltaTime, speed / 5   * Time.deltaTime, 0);
            ball.transform.localScale = scale;
        }
        else if (goBall == false && timer <= Time.time)
        {
            goBall = true;
        }
    }

}
