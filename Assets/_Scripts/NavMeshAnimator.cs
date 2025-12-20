using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAnimator : MonoBehaviour
{
    NavMeshAgent navMesh;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", navMesh.velocity.magnitude);
    }
}
