using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Inputs;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;
using shootandRun1.Abstracts.Controllers;


namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")]
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _moveSpeed = 10f;     
        [SerializeField] Transform _turnTransform;


        IInputReader _input;
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;
        CharacterAnimation _animation;
        InventoryController _inventory;

        Vector3 _direction; 

        public Transform TurnTransform => _turnTransform;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _inventory = GetComponent<InventoryController>();
        }
        private void Update()
        {
            _direction = _input.Direction;
            //Debug.Log(_input.Rotation);
            
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
            _mover.MoveAction(_direction, _moveSpeed);
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }
    }
}

