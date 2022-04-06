using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using shootandRun1.Managers;
using System;

namespace shootandRun1.Uis
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        TMP_Text _levelText;

        private void Awake()
        {
            _levelText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextWave;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextWave;
        }

        void HandleOnNextWave(int levelValue)
        {
            _levelText.text = levelValue.ToString();
        }
    }
}

