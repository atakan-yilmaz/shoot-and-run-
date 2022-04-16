using shootandRun1.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shootandRun1.Uis
{
    public class PlayerAddButton : MonoBehaviour
    {
        Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);    
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);    
        }

        private void OnButtonClicked()
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }
}

