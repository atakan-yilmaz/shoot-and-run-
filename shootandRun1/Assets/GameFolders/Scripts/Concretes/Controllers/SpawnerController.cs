using shootandRun1.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;
        [SerializeField] float _maxTime;

        float _currentTime = 0f;

        private void Start()
        {
            _maxTime = _spawnInfo.RandamSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandamSpawnMaxTime;
        }
    }
}

