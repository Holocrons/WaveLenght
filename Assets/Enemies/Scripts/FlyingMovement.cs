using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rigidBody;
    private int direction = 1;
    public Transform player;
    private Transform myTransform;
    public float range = 5;
    public float attackRange = 1;
    public float rotationSpeed = 0.2f;
    private EnemyAttack attack;
    private Vector3 initialPos;
    private Vector3 playerCenterPos;
    private CapsuleCollider playerCollider;
    private float rotStep;
    private float moveStep;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        attack = GetComponent<EnemyAttack>();
        myTransform = transform;
        initialPos = myTransform.position;
        moveStep = speed * Time.deltaTime;
        rotStep = rotationSpeed * Time.deltaTime;
        if (!player)
            player = GameObject.FindWithTag("Player").transform;
        if (player)
            playerCollider = player.GetComponent<CapsuleCollider>();
    }
    void FixedUpdate() {
        AIMovement();
    }

    private void ReturnToPos() {
        if (myTransform.position != initialPos) {
            Vector3 direction = initialPos - myTransform.position;
            Vector3 newRot = Vector3.RotateTowards(myTransform.forward, direction, rotStep, 0.0f);
            if (myTransform.rotation == Quaternion.LookRotation(newRot)) {
                myTransform.position = Vector3.MoveTowards(myTransform.position, initialPos, moveStep);
            } else {
                myTransform.rotation = Quaternion.LookRotation(newRot);
            }
        }
    }

    private void AIMovement () {
        if (player)
        {
            playerCenterPos = player.position + new Vector3(0, playerCollider.center.y, 0);
        }
        float distance = Vector3.Distance(myTransform.position, playerCenterPos);
        int playerDirection = (int)(player.position.x - myTransform.position.x);
        if (distance <= range) {
            Vector3 direction = playerCenterPos - myTransform.position;
            RaycastHit hit;
            bool hasHit = Physics.Raycast(myTransform.position, direction, out hit, 100);
            if (hasHit) {
                if (hit.transform.position == player.position) {
                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(direction), rotStep);
                    // Vector3 newRot = Vector3.RotateTowards(myTransform.forward, direction, rotStep, 0.0f);
                    // myTransform.rotation = Quaternion.LookRotation(newRot);
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
                    if (distance > attackRange) {
                        myTransform.position = Vector3.MoveTowards(myTransform.position, playerCenterPos, moveStep);
                    } else
                        attack.Fire(playerCenterPos - myTransform.position, myTransform.position);
                }
                else {
                    Debug.DrawRay(transform.position, direction * 50, Color.blue);
                    ReturnToPos();
                }
            }
        } else
            ReturnToPos();
    }
}
