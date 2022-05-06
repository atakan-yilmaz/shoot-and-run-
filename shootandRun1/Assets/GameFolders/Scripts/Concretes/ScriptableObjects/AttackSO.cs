using UnityEngine;


namespace shootandRun1.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/Create New", order =51)]


    public class AttackSO : ScriptableObject
    {
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _floatValue = 1f; //distance property
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] AnimatorOverrideController _animatorOverride;
        [SerializeField] AudioClip _clip;

        //private Transform transform; //close

        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;
        public AudioClip Clip => _clip;

        //public IAttackType GetAttackType(params Transform[] transforms )
        //{
        //    if (_attackType == AttackTypeEnum.Range)
        //    {
        //        return new RangeAttack(this, transforms);
        //    }
        //    else
        //    {
        //        return new MeleeAttackType(this, transforms);
        //    }
        //}
    }
}