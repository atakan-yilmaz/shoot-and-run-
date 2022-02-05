using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using shootandRun1.Abstracts.States;
using shootandRun1.Abstracts.Controllers;

namespace shootandRun1.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;

        float _maxTime = 5f;
        float _currentTime = 0f;

        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnStart()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnStart)}");
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                GameObject.Destroy(_enemyController.transform.gameObject);
            }
        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {
            
        }
    }
}

