using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public string Info { get; protected set; }

    public string Name { get; protected set; }

    private float age;
    public float Age
    {
        get { return age; }
        protected set 
        {
            if (value < 0)
            {
                Debug.Log("Age cannot be set to negative number.");
                return;
            }
            age = value;
        }
    }

    protected bool atDestination = true;
    protected Animator anim;
    protected NavMeshAgent m_Agent;
    protected float Speed = 3;

    protected void Awake()
    {
        anim = GetComponent<Animator>();

        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    protected void Update()
    {
        if (m_Agent.transform.position == m_Agent.destination)
        {
            atDestination = true;
        }
        else
        {
            atDestination = false;
        }

        if (m_Agent != null && !atDestination && anim != null)
        {
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }
    }

    public virtual void Vocalize()
    {
        Debug.Log("Animal base class Vocalize() method has been called. You should never see this.");
    }

    public virtual void GoTo(Vector3 position)
    {
        //we don't have a target anymore if we order to go to a random point.
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }
}
