using shootandRun1.Abstracts.Movements;
using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;
        float _moveSpeed; 
        public MoveWithCharacterController(PlayerController playerController, float moveSpeed)
        {
            _characterController = playerController.GetComponent<CharacterController>();
            _moveSpeed = moveSpeed;
        }
        public void MoveAction(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * Time.deltaTime * _moveSpeed ;

            _characterController.Move(movement);
        }
    }
}

