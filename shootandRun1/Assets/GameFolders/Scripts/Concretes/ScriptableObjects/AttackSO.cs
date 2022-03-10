using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.Combats;


namespace shootandRun1.ScriptableObjects
{

    enum AttackTypeEnum : byte
    {
        Range,Melee
    }

    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/Create New", order =51)]

    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _floatValue = 1f; //distance property
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] AnimatorOverrideController _animatorOverride;

        //private Transform transform; //close

        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;

        public IAttackType GetAttackType(Transform transform )
        {
            if (_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttack(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }
    }
}