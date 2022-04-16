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

        void Awake()
        {
            _button = GetComponent<Button>();
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        private void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel(name:"Game");
        }
    }
}