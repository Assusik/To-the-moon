using System;
using UnityEngine;

namespace Skripts.Game.Rocket
{
    public static class EventSystem
    {
        public static event Action<float> OnFuelChanged;
        public static event Action<float> OnSpeedChanged;
        public static event Action<float> OnAltitudeChanged;
        public static event Action<float> OnMaxFuelChanged;
        public static event Action<float> OnModuleChanged;

        public static void RaiseFuelChanged(float value) => OnFuelChanged?.Invoke(value);
        public static void RaiseSpeedChanged(float value) => OnSpeedChanged?.Invoke(value);
        public static void RaiseAltitudeChanged(float value) => OnAltitudeChanged?.Invoke(value);
        public static void RaiseMaxFuelChanged(float value) => OnMaxFuelChanged?.Invoke(value);
        public static void RaiseModuleChanged(float value) => OnModuleChanged?.Invoke(value);
    }
}