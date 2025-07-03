using System;
using Skripts.Game.Rocket;
using Skripts.Game.UI;
using UnityEngine;

namespace Skripts.Game
{
    public class GameManager:MonoBehaviour
    {
        [SerializeField] private RocketController _rocketController;
        [SerializeField] private UIController _uiController;
        private void Start()
        {
            _uiController.Initialize();
            _rocketController.Initialize();
        }
    }
}