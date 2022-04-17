using UnityEngine;


namespace shootandRun1.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; }
        bool IsAttackButtonPress { get; }
        bool IsInventoryButtonPressed { get; }
    }
}