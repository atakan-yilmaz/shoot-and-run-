using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
    }
}

