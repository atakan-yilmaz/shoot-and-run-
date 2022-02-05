using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using UnityEngine.AI;
using shootandRun1.Abstracts.Combats;
using shootandRun1.States.EnemyStates;

namespace shootandRun1.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        IHealth _health;
        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;

        public IMover Mover { get; private set; }

        public InventoryController Inventory { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public Transform Target { get; set; }
        public float Magnitude => _navMeshAgent.velocity.magnitude;

        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        bool _canAttack;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();

            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
        }

        void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState(this);
            ChaseState chaseState = new ChaseState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
        }
       
        private void Update()
        {
            _stateMachine.Tick();
        }

        void FixedUpdate()
        {
            _stateMachine.TickFixed();
        }
        private void LateUpdate()
        {
            _stateMachine.TickLate();
        }
    }
}