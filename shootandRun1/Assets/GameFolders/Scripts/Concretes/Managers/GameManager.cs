using shootandRun1.Abstracts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace shootandRun1.Managers
{
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        [SerializeField] int _waveMaxCount = 100;

        public int WaveMaxCount => _waveMaxCount;
        public bool IsWaveFinished => _waveMaxCount <= 0;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelAsync(name));
        }

        private IEnumerator LoadLevelAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveCount()
        {
            if (IsWaveFinished) return;

            _waveMaxCount--;
        }
    }
}
