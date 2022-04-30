using shootandRun1.Abstracts.Movements;
using shootandRun1.Animations;
using shootandRun1.Combats;
using shootandRun1.Controllers;
using UnityEngine;


namespace shootandRun1.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        public Dead Dead { get; }
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }

        Transform Target { get; set; }

        float Magnitude { get; }
        void FindNearestTarget();
    }
}