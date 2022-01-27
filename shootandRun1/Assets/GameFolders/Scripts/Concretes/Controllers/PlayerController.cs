using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Inputs;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;
using shootandRun1.Animations;

namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _moveSpeed = 10f;
        [Header("Movement Information")]
        [SerializeField] Transform _turnTransform;
        [SerializeField] WeaponController _currentWeapon;


        IInputReader _input;
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;
        CharacterAnimation _animation;

        Vector3 _direction; 

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
            //Debug.Log(_input.Rotation);
            
            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPress)
            {
                _currentWeapon.Attack();
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

