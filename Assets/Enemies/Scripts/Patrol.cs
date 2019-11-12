using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private GroundEnemyMovement movement;
    public Transform player;
    private Transform myTransform;
    public float range = 5;
    public float attackRange = 1;
    private EnemyAttack attack;
    private BoxCollider boxCollider;
    public float rotationSpeed = 0.2f;
    private float rotStep;
    private bool animationIsPlaying = false;
    private Animator anim;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        movement = GetComponent<GroundEnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        myTransform = transform;
        agent.autoBraking = false;
        rotStep = rotationSpeed * Time.deltaTime;

        GotoNextPoint();
    }

    private IEnumerator PlayAnimation(string animName) {
        anim.Play(animName, 0);
        yield return new WaitForEndOfFrame();
        Debug.Log(animName);
        Debug.Log("current clip length = " + anim.GetCurrentAnimatorStateInfo(0).length);
        agent.isStopped = true;
        animationIsPlaying = true;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        animationIsPlaying = false;
        agent.isStopped = false;
    }

    private IEnumerator WaitForAnimation(string animName)
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(animName);
        Debug.Log("current clip length = " + anim.GetCurrentAnimatorStateInfo(0).length);
        agent.isStopped = true;
        animationIsPlaying = true;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        animationIsPlaying = false;
        agent.isStopped = false;
    }

    private void GotoNextPoint() {
        StartCoroutine(PlayAnimation("Idle"));
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        agent.isStopped = false;
    }

    void Update() {
        // float distance = Vector3.Distance(myTransform.position, player.position);
        if (!animationIsPlaying) {

            Vector3 centerPos = myTransform.position + new Vector3(0, boxCollider.center.y, 0);
            float distance = Vector3.Distance(centerPos, player.position);

            if (distance <= range)
            {
                if (distance < attackRange)
                {
                    agent.isStopped = true;
                    attack.MeleeAttack(player.position - centerPos, centerPos);
                    StartCoroutine(WaitForAnimation("Attack"));
                    // attack.MeleeAttack(player.position - myTransform.position, myTransform.position);
                    // Vector3 direction = player.position - centerPos;
                    // Vector3 newRot = Vector3.RotateTowards(myTransform.forward, direction, rotStep, 0.0f);
                    // if (myTransform.rotation == Quaternion.LookRotation(newRot))
                    // {
                    //     attack.MeleeAttack(player.position - centerPos, centerPos);
                    // }
                    // else
                    // {
                    //     myTransform.rotation = Quaternion.LookRotation(newRot);
                    // }
                }
                else {
                    agent.isStopped = false;
                    agent.SetDestination(player.position);
                }
            }
            else
            {
                // if (movement.Follow()) {
                //     agent.isStopped = true;
                // } else {
                // agent.isStopped = false;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
            }
        }
    }
}
