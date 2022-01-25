using UnityEngine;
using UnityEngine.InputSystem;
using shootandRun1.Abstracts.Inputs;

namespace shootandRun1.Inputs
{
    public class InputReader : MonoBehaviour,IInputReader
    {
        public Vector3 Direction { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, y: 0f, z: oldDirection.y);
        }
    }
}