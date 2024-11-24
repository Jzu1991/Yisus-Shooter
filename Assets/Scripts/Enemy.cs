using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    private bool isDead = false;
    public Transform player;
    private float delay = 3;
    private int vida = 4;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.SetBool("Perseguir", true);

    }


    void Update()
    {
        if (isDead == false) 
        {
            SetDestination(player.position);
        }
    }

    public void SetDestination(Vector3 newdestination)
    {
        agent.destination = newdestination;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            vida--;
           
            if (vida <= 0) 
            {

                TriggerDeath();
            }
        }

        

    }
    private void TriggerDeath()
    {
        
        agent.enabled = false;
        isDead = true;

        // Activa la animación de muerte
        anim.SetBool("NoVida", true);


        StartCoroutine(ExecuteAfterDelay(delay));
    }

    private IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}

