using shootandRun1.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.Controllers
{
    public interface IEntityController 
    {
        public Transform transform { get; }

    }
}