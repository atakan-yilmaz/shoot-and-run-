using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.Combats
{
    public interface IHealth
    {
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}
