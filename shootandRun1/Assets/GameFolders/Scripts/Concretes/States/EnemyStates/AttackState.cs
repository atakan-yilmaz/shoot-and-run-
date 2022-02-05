using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using shootandRun1.Abstracts.States;
using shootandRun1.Abstracts.Controllers;

namespace shootandRun1.States.EnemyStates 
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;

        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnStart()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnStart)}");
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnExit)}");

            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
        }

        public void TickFixed()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
        }

        public void TickLate()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}

