using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.ScriptableObjects;
using shootandRun1.Managers;

namespace shootandRun1.Combats
{
    public class RangeAttack : IAttackType
    {
        Camera _camera;
        AttackSO _attackSO;
        
        public RangeAttack(Transform transformObject, AttackSO attackSO)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSO = attackSO;
            //SoundManager.Instance.SoundControllers[1].SetClip(_attackSO.Clip);
        }

        public void AttackAction()
        { 
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, _attackSO.FloatValue, _attackSO.LayerMask))
            {
                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }

            SoundManager.Instance.RangeAttackSound(_attackSO.Clip, _camera.transform.position);
        }
    }
}