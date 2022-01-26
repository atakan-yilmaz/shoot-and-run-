using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Controllers;  

namespace shootandRun1.Movements
{
    public class RotatorX : IRotator
    {
        PlayerController _playerController;

        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void RotationAction(float direction, float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction * Time.deltaTime * speed);
        }
    }
}

