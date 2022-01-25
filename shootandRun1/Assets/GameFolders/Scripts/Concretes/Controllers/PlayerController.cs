using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Inputs;

namespace shootandRun1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IInputReader _input;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }

        private void Update()
        {
            Debug.Log(_input.Direction);
        }
    }
}

