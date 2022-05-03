using UnityEngine;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using UnityEngine.AI;
using shootandRun1.Abstracts.Combats;
using shootandRun1.States.EnemyStates;
using shootandRun1.Combats;
using shootandRun1.Managers;

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
        public Dead Dead { get; private set; }
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
            Dead = GetComponent<Dead>();
        }
        void Start()
        {
            FindNearestTarget();

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

        void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this); 
        }

        public void FindNearestTarget()
        {
            Transform nearest = EnemyManager.Instance.Targets[0];

            foreach (Transform target in EnemyManager.Instance.Targets)
            {
                float nearestValue = Vector3.Distance(nearest.position, transform.position);
                float newValue = Vector3.Distance(target.position, transform.position);

                if (newValue < nearestValue)
                {
                    nearest = target;
                }
            }

            Target = nearest;
        }
    }
}