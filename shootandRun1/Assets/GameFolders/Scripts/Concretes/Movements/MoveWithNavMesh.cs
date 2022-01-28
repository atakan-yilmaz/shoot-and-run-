using shootandRun1.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using shootandRun1.Controllers;
using shootandRun1.Abstracts.Controllers;


namespace shootandRun1.Movements
{
    public class MoveWithNavMesh : IMover
    {
        NavMeshAgent _navMeshAgent;

        public MoveWithNavMesh(IEntityController entityController)
        {
            _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            
            _navMeshAgent.SetDestination(direction);
        }
    }
}

