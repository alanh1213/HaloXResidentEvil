using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] Transform movePositionTransform;
    NavMeshAgent _navMeshAgent;

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    private void Update() {
        _navMeshAgent.destination = movePositionTransform.position;
    }
}
