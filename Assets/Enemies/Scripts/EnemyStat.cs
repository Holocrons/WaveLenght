using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int healthPoints = 3;
    public bool deathPlaying = false;
    public bool hasDeathAnim = false;
    private Animator anim;
    public GameObject explosion;

    void Start() {
        anim = GetComponent<Animator>();
    }

    private IEnumerator PlayAnimation(string animName)
    {
        anim.Play(animName, 0);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage) {
        healthPoints -= damage;
    }

    void Explode()
    {
        GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
        var exp = go.GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(go, exp.main.duration);
        Destroy(gameObject);
    }

    void Update() {
        if (healthPoints <= 0 && !deathPlaying) {
            deathPlaying = true;
            if (hasDeathAnim)
                StartCoroutine(PlayAnimation("Death"));
            else if (explosion)
                Explode();
        }
    }

    // void OnTriggerEnter(Collider collider) {
    //     if (collider.transform.CompareTag("shoot")) {
    //         TakeDamage(1);
    //         Destroy(collider.gameObject);
    //     }
    // }
}
