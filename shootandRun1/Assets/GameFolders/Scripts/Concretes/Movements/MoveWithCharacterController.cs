using shootandRun1.Abstracts.Movements;
using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Controllers;


namespace shootandRun1.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;

        public MoveWithCharacterController(IEntityController entityController)
        {
            _characterController = entityController.transform.GetComponent<CharacterController>();
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

