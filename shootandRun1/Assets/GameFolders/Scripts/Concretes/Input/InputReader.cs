using UnityEngine;
using UnityEngine.InputSystem;
using shootandRun1.Abstracts.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace shootandRun1.Inputs
{
    public class InputReader : MonoBehaviour,IInputReader
    {
        public Vector3 Direction { get; private set; }

        public Vector2 Rotation { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, y: 0f, z: oldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }
    }
}