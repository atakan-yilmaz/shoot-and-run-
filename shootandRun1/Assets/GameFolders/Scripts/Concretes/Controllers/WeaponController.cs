using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Combats;
using shootandRun1.Combats;
using shootandRun1.ScriptableObjects;



namespace shootandRun1.Controllers 
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] Transform _transformObject; //camera 

        // ----------------------------------**----------------------------------- \\

        [SerializeField] AttackSO _attackSO;

        float _currentTime = 0f;
        IAttackType _attackType;

        private void Awake()
        {
            _attackType = new RangeAttack(_transformObject, _attackSO); //camera position
        }

        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSO.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();

            _currentTime = 0f;
        }      
    }
}


