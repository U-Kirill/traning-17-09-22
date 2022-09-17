using System;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.Enemy
{
    public class EnemyHealthPresenter : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _enemyHealth.Damaged += RefreshBar;
            _enemyHealth.Healed += RefreshBar;
        }
        
        private void OnDisable()
        {
            _enemyHealth.Damaged -= RefreshBar;
            _enemyHealth.Healed -= RefreshBar;
        }

        private void Start() => RefreshBar();

        private void RefreshBar()
        {
            _slider.value = _enemyHealth.HealPercent;
        }
    }
}