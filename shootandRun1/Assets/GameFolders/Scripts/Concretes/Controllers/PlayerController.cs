using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Inputs;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Movements;

namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;
        [Header("Movement Information")]


        IInputReader _input;
        IMover _mover;

        Vector3 _direction;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this, _moveSpeed);
        }

        private void Update()
        {
            _direction = _input.Direction;
        }
        private void FixedUpdate()
        {
            _mover.MoveAction(_direction);
        }
    }
}

