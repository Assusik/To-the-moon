

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Skripts.Game.Rocket
{
    public class RocketController : MonoBehaviour
    {
        [SerializeField] EngineRocketModule  engineRocketModule;
        [SerializeField] Rigidbody2D rocketRigidbody2D;
        //private RocketModuleParams _rocketModuleParams;
        private IRocketModule _curentRocketModule;

        private List<IRocketModule> _rocketModules = new();
        
        private void Start()
        {
            _rocketModules = GetComponentsInChildren<IRocketModule>().ToList();
            foreach (var module in _rocketModules)
            {
                var moduleParams = new RocketModuleParams
                {
                    Fuel = 50,
                    Thurst = 10
                };

                module.Initialize(rocketRigidbody2D, moduleParams);
                module.OnDetach += SetCurrentModule;
            }
            
            SetCurrentModule();
            

        }

        private void FixedUpdate()
        {
            _curentRocketModule?.Move();
            
        }

        private void SetCurrentModule()
        {
            if (_rocketModules.Count == 0)
            {
                _curentRocketModule = null;
                return;
            }

            _curentRocketModule = _rocketModules[0];
            _rocketModules.RemoveAt(0);
            
        }
        
    }
}