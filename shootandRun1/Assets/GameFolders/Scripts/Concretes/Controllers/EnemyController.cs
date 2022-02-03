using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using UnityEngine.AI;
using shootandRun1.Abstracts.Combats;


namespace shootandRun1.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {

        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController;

        Transform _playerTransform;
        bool _canAttack;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
        }

        void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }
       
        private void Update()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_playerTransform.position,moveSpeed: 10f);

            _canAttack = Vector3.Distance(_playerTransform.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

            //Debug.Log(_canAttack);
        }

        void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }
    }
}

