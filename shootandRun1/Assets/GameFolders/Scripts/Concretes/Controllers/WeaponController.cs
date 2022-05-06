using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.ScriptableObjects;


namespace shootandRun1.Controllers 
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;


        float _currentTime = 0f;
        IAttackType _attackType;
        public AnimatorOverrideController AnimatorOverrideController => _attackType.AttackInfo.AnimatorOverride;

        public RuntimeAnimatorController AnimatorOverride { get; internal set; }

        private void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }

        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackType.AttackInfo.AttackMaxDelay;
        }
        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();

            _currentTime = 0f;
        }
    }
}