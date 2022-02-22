using shootandRun1.Abstracts.Controllers;
using shootandRun1.Abstracts.Movements;
using shootandRun1.Animations;
using shootandRun1.Combats;
using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        public IMover Mover { get; }
        public Dead Dead { get; }
        public InventoryController Inventory { get; }
        public CharacterAnimation Animation { get; }

        Transform Target { get; set; }

        public float Magnitude { get; }
    }
}

