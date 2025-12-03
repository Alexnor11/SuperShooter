using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }

    public EnemyState currentState;

    public Sight sightSensor;
    private Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;

    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
    }

    private void Update()
    {
        if(currentState == EnemyState.GoToBase) { GoToBase(); }
        else if(currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else if (currentState == EnemyState.AttackPlayer) { AttackPlayer(); }
    }



    void GoToBase() 
    {
        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }
    void AttackBase() { print("AttackBase"); }
    
    void ChasePlayer() 
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer <= baseAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer() 
    { 
       if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        } 

       float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
