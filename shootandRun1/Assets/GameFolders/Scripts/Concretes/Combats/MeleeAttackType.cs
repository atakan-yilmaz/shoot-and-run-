using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.ScriptableObjects;
using shootandRun1.Managers;

namespace shootandRun1.Combats
{
    public class MeleeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;

        public AttackSO AttackInfo => _attackSO;

        //public MeleeAttackType(AttackSO attackSO, params Transform[] transforms)
        //{
        //    _transformObject = transforms[0];
        //    _attackSO = attackSO;
        //    SoundManager.Instance.SoundControllers[2].SetClip(_attackSO.Clip);
        //}
        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSO.FloatValue, _attackSO.LayerMask);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }

            SoundManager.Instance.MeleeAttackSound(_transformObject.position);
        }
    }
}