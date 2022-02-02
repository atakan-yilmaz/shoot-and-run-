using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Movements
{
    [RequireComponent(typeof(CharacterController))]
    public class Gravity : MonoBehaviour
    {
        [SerializeField] float _gravity = 9.81f;
        CharacterController _characterController;
        Vector3 _velocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        private void Update()
        {
            if (_characterController.isGrounded) _velocity.y = 0f;
            {
                _velocity.y += _gravity * Time.deltaTime;

                _characterController.Move(_velocity * Time.deltaTime);
            }
        }
    }
}

