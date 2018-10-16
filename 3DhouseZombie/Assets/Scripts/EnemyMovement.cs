using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform player;

    UnityEngine.AI.NavMeshAgent navMesh;
    Animator anim;
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	void Update ()
    {
        navMesh.SetDestination(player.position);

        if(navMesh.remainingDistance <= navMesh.stoppingDistance)
            anim.SetBool("IsIdle" , true);
        else
            anim.SetBool("IsIdle", false);

    }


    void Move()
    {
        Vector3 Direction = player.transform.position - transform.position;

        if (Direction.magnitude < 1)
            return;

        Direction.Normalize();
        Quaternion newRotation = Quaternion.LookRotation(Direction);
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                     newRotation, Time.deltaTime * 10f);

        transform.position += Direction * Time.deltaTime * 2f;
    }
}







