using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Inputs;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Combats;

namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")]
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _moveSpeed = 10f;     
        [SerializeField] Transform _turnTransform;

                
        IInputReader _input;
        IRotator _xRotator;
        IRotator _yRotator;
        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        InventoryController _inventory;

        Vector3 _direction; 

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _inventory = GetComponent<InventoryController>();
        }

        private void OnEnable()
        {
            _health.OnDead += () => _animation.DeadAnimation("death");
        }
        private void Update()
        {
            _direction = _input.Direction;
            //Debug.Log(_input.Rotation);

            if (_health.IsDead) return;

            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }

            //Debug.Log(_input.IsInventoryButtonPressed); klavye q islemi 

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
        }
    }
}