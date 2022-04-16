using shootandRun1.Controllers;
using UnityEngine;


namespace shootandRun1.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner Info", menuName = "Combat/Spawner Info/Create New",order = 51)]

    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _maxSpawnTime = 15f;
        [SerializeField] float _minSpawnTime = 3f;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandamSpawnMaxTime => Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}