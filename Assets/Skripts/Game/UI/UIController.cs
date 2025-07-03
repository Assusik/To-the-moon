using System;
using Skripts.Game.Rocket;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skripts.Game.UI
{
    public class UIController:MonoBehaviour
    {
        [SerializeField] private Slider _fuelSlider;
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private TextMeshProUGUI _heightText;

        public void Initialize()
        {
            EventSystem.OnMaxFuelChanged += SetMaxFuel;
            EventSystem.OnFuelChanged += FuelChanged;
            EventSystem.OnAltitudeChanged += OnHeightChanged;
            EventSystem.OnSpeedChanged += OnSpeedChanged;
        }

        private void SetMaxFuel(float newFuel) => _fuelSlider.maxValue = newFuel;
        private void FuelChanged(float newFuel) =>_fuelSlider.value = newFuel;
        private void OnHeightChanged(float newHeight) => _heightText.text = newHeight.ToString();
        private void OnSpeedChanged(float newSpeed) => _speedText.text = newSpeed.ToString();


        private void OnDisable()
        {
            EventSystem.OnMaxFuelChanged -= SetMaxFuel;
            EventSystem.OnFuelChanged -= FuelChanged;
            EventSystem.OnAltitudeChanged -= OnHeightChanged;
            EventSystem.OnSpeedChanged -= OnSpeedChanged;
        }
    }
}