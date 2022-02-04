using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.States
{
    public interface IState
    {
        void Tick();
        //void FixedTick();
        //void LateUpdate();
    }
}

