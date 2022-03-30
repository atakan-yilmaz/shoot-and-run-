using shootandRun1.Abstracts.Helpers;
using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Managers
{
    public class EnemyManager : SingletonMonoBehavior<EnemyManager>
    {
        [SerializeField] List<EnemyController> _enemies;
        [SerializeField] int _maxCountOnGame = 15;

        public bool CanSpawn => _maxCountOnGame > _enemies.Count; 

        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _enemies = new List<EnemyController>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }
}

