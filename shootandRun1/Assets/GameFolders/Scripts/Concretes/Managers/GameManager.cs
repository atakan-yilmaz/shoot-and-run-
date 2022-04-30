using shootandRun1.Abstracts.Helpers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace shootandRun1.Managers
{
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        [SerializeField] int _waveLevel = 1;
        [SerializeField] float _waitNextLevel = 10f;
        [SerializeField] float _waveMultiple = 1.2f;
        [SerializeField] int _maxWaveBoundaryCount = 50;
        [SerializeField] int _playerCount = 0;

        int _currentWaveMaxCount;

        public int PlayerCount => _playerCount;

        public bool IsWaveFinished => _currentWaveMaxCount <= 0;

        public event System.Action<int> OnNextWave;

        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        private void Start()
        {
            _currentWaveMaxCount = _maxWaveBoundaryCount;
        }

        public void LoadLevel(string name)
        {
            StartCoroutine(routine: LoadLevelAsync(name));
        }

        private IEnumerator LoadLevelAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveCount()
        {
            if (IsWaveFinished)
            {
                if (EnemyManager.Instance.IsListEmpty)
                {
                    StartCoroutine(StartNextWaveAsync());
                }
            }
            else
            {
                _currentWaveMaxCount--;
            }
        }

        private IEnumerator StartNextWaveAsync()
        {
            yield return new WaitForSeconds(_waitNextLevel);
            _maxWaveBoundaryCount = System.Convert.ToInt32(_maxWaveBoundaryCount * _waveMultiple);
            _currentWaveMaxCount = _maxWaveBoundaryCount;
            _waveLevel++;
            OnNextWave?.Invoke(_waveLevel);
        }

        public void IncreasePlayerCount()
        {
            _playerCount++;
        }

        public void ReturnMenu()
        {
            if (_playerCount > 1)
            {
                _playerCount--;
            }
            else
            {
                _playerCount = 0;
                EnemyManager.Instance.DestroyAllEnemies();
                EnemyManager.Instance.Targets.Clear();
                LoadLevel("Menu");
            }
        }
    }
}