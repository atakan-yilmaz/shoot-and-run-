using UnityEngine;
using shootandRun1.Abstracts.Helpers;
using shootandRun1.Controllers;

namespace shootandRun1.Managers
{
    public class SoundManager : SingletonMonoBehavior<SoundManager>
    {
        [SerializeField] AudioClip _clip;

        SoundController[] _soundControllers;

        public SoundController[] SoundControllers => _soundControllers;

        private void Awake()
        {
            SetSingletonThisGameObject(this);

            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void RangeAttackSound(Vector3 position)
        {
            _soundControllers[1].PlaySound(position);
        }

        public void MeleeAttackSound(Vector3 position)
        {
            _soundControllers[2].PlaySound(position);
        }

        public void RangeAttackSound(AudioClip clip, Vector3 position)
        {
            for (int i = 1; i < _soundControllers.Length; i++)
            {
                if (_soundControllers[i].IsPlaying) continue;

                _soundControllers[i].SetClip(clip);
                _soundControllers[i].PlaySound(position);

                break;
            }
        }
    }
}