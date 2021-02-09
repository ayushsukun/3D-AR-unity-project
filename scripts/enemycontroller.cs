using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    public Transform target;
    public float danger_zone= 10f;
    public NavMeshAgent agent;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance<= agent.stoppingDistance)
        {
            anim.SetTrigger("attack");
        }

        else if (distance<= danger_zone)
        {
            agent.SetDestination(target.position);
            anim.SetTrigger("walk");
        }

        else
        {
            anim.SetTrigger("idle");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, danger_zone);
    }

}
