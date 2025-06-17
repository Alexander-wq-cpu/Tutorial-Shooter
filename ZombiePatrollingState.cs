using NUnit.Framework;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrollingState : StateMachineBehaviour
{
    float timer;
    public float patrolingTime = 10f;

    Transform player;
    NavMeshAgent agent;

    public float detectionArea = 18f;
    public float patrolSpeed = 2f;

    List<Transform> waypointsList = new List<Transform>();
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        // Инициализируем переменные
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = patrolSpeed;
        timer = 0;

        //получаем список всех waypoint ,выбираем случайное место из списка, двигаем зомби в это место
        GameObject waypointCluster = GameObject.FindGameObjectWithTag("Waypoints");
        foreach(Transform t in waypointCluster.transform)
        {
            waypointsList.Add(t);
        }

        Vector3 nextPosition = waypointsList[Random.Range(0, waypointsList.Count)].position;
        agent.SetDestination(nextPosition);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(SoundManager.Instance.zombieChannel.isPlaying == false)
        {
            SoundManager.Instance.zombieChannel.clip = SoundManager.Instance.zombieWalking;
            SoundManager.Instance.zombieChannel.PlayDelayed(1f);
        }

        //если зомби прибыл в место назначения, он двигается в следующее место
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointsList[Random.Range(0, waypointsList.Count)].position);
        }

        //переход в idle state
        timer += Time.deltaTime;
        if(timer > patrolingTime)
        {
            animator.SetBool("isPatroling", false);
        }

        // --- Transition to Chasing State --- //
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionArea)
        {
            animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(agent.transform.position);
        SoundManager.Instance.zombieChannel.Stop();
    }
}
