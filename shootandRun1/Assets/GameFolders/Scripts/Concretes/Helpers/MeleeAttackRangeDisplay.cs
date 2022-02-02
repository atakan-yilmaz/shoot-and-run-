using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.ScriptableObjects;

namespace shootandRun1.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] float _radius = 1f;
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _radius);
        }
    }
}

