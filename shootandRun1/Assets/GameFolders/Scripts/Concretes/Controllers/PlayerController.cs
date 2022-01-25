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
        [SerializeField] float _moveSpeed = 10f;
        [Header("Movement Information")]


        IInputReader _input;
        IMover _mover;
        CharacterAnimation _animation;

        Vector3 _direction;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
        }
        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
        }
    }
}

