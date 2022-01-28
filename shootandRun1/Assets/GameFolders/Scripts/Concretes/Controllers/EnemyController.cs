using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;

namespace shootandRun1.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
    }   
}

