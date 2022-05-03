using UnityEngine;
using UnityEngine.InputSystem;
using shootandRun1.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;

namespace shootandRun1.Inputs
{
    public class InputReader : MonoBehaviour,IInputReader
    {
        int _index;

        public Vector3 Direction { get; private set; }

        public Vector2 Rotation { get; private set; }

        public bool IsAttackButtonPress { get; private set; }
        public bool IsInventoryButtonPressed { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, y: 0f, z: oldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }

        public void OnAttack (InputAction.CallbackContext context)
        {
            IsAttackButtonPress = context.ReadValueAsButton();
        }

        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            //IsInventoryButtonPressed = context.ReadValueAsButton();
            if (IsInventoryButtonPressed && context.action.triggered) return;

            StartCoroutine(WaitOnFrameAsync());
        }

        IEnumerator WaitOnFrameAsync()
        {
            IsInventoryButtonPressed = true && _index % 2 == 0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
  
            _index++;
        }
    }
}