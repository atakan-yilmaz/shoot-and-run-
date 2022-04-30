using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using shootandRun1.Abstracts.States;
using shootandRun1.Abstracts.Controllers;

namespace shootandRun1.States.EnemyStates
{

    public class ChaseState : IState
    {
        IEnemyController _enemyController;
        float _speed = 10f;

        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnStart()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnStart)}");
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
            _enemyController.Mover.MoveAction(_enemyController.transform.position, 0f);
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _speed);
        }

        public void TickFixed()
        {
            _enemyController.FindNearestTarget();
        }

        public void TickLate()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}