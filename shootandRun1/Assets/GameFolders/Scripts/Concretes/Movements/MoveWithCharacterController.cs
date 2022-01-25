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

        public MoveWithCharacterController(PlayerController playerController)
        {
            _characterController = playerController.GetComponent<CharacterController>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction == Vector3.zero) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * Time.deltaTime * moveSpeed;

            _characterController.Move(movement);
        }
    }
}

