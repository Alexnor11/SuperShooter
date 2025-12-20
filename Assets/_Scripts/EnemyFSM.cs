using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }

    public EnemyState currentState;
    public Sight sightSensor;
    public GameObject bulletPrefab;
    
    public float baseAttackDistance;
    public float playerAttackDistance;
    public float lastShootTime;    
    public float fireRate;
    public AudioSource shootSound;
    public GameObject shootPoint;
    

    private Transform baseTransform;
    private NavMeshAgent agent;


    Animator animator;

    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;        
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
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
        animator.SetBool("Shooting", false);
        agent.isStopped = false;

        agent.SetDestination(baseTransform.position);
        
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
    
    void ChasePlayer() 
    {
        
        agent.isStopped = false;

        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer() 
    {
        agent.isStopped = true;
        
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

       float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void Shoot()
    {
        animator.SetBool("Shooting", true);
        
        var timeSincleLastShoot = Time.time - lastShootTime;
        if(timeSincleLastShoot > fireRate && Time.timeScale > 0)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            Instantiate(shootSound, transform.position, transform.rotation);
                    
        }       
    }

    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
