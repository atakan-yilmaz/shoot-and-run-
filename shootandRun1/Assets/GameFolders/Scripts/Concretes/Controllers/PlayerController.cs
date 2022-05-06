using UnityEngine;
using shootandRun1.Abstracts.Inputs;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Combats;
using shootandRun1.Managers;

namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")]
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _moveSpeed = 10f;     
        [SerializeField] Transform _turnTransform;
        [SerializeField] Transform _ribTransform;

        [Header("Uis")]
        [SerializeField] GameObject _gameOverPanel;

                
        IInputReader _input;
        IRotator _xRotator;
        IRotator _yRotator;
        IMover _mover;
        IHealth _health;
        IRotator _ribRotator;
        CharacterAnimation _animation;
        InventoryController _inventory;

        Vector3 _direction;
        Vector3 _rotation;

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _ribRotator = new RibRotator(_ribTransform);
            _inventory = GetComponent<InventoryController>();
        }

        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("death");
                _gameOverPanel.SetActive(true);
            };

            EnemyManager.Instance.Targets.Add(this.transform);
        }
        private void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }
        private void Update()
        {
            if (_health.IsDead) return;

            _direction = _input.Direction;
            _rotation = _input.Rotation;

            _xRotator.RotationAction(_rotation.x, _turnSpeed);
            _yRotator.RotationAction(_rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }
        private void FixedUpdate()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_direction, _moveSpeed);
        }
        private void LateUpdate()
        {
            if (_health.IsDead) return;

            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPress);

            _ribRotator.RotationAction(_rotation.y * -1, _turnSpeed);
        }
    }
}