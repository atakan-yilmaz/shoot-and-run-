using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.ScriptableObjects;
using shootandRun1.Managers;
using shootandRun1.Controllers;

namespace shootandRun1.Combats
{
    public class RangeAttack : MonoBehaviour, IAttackType
    {
        [SerializeField] AttackSO _attackSO;
        [SerializeField] Camera _camera;
        [SerializeField] BulletFxController _bulletFx;
        [SerializeField] Transform _bulletPoint;

        public AttackSO AttackInfo => _attackSO;

        //public RangeAttack(AttackSO attackSO,params Transform[] transforms)
        //{
        //    _camera = transforms[0].GetComponent<Camera>();
        //    _bulletPoint = transforms[1];
        //    _attackSO = attackSO;
        //    //SoundManager.Instance.SoundControllers[1].SetClip(_attackSO.Clip);
        //}

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

            var bullet = Instantiate(_bulletFx, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(ray.direction);

            SoundManager.Instance.RangeAttackSound(_attackSO.Clip, _camera.transform.position);
        }
    }
}