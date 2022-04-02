using shootandRun1.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shootandRun1.Uis
{
    public class StartButton : MonoBehaviour
    {
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        private void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel("Game");
        }
    }
}

