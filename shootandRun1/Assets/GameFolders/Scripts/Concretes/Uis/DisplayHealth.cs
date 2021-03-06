using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using shootandRun1.Combats;
using System;

namespace shootandRun1.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;

        void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += HandleTakeHit;
        }
        void HandleTakeHit(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
        }
    }
}