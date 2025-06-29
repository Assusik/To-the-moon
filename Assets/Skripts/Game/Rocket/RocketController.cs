

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Skripts.Game.Rocket
{
    public class RocketController : MonoBehaviour
    {
        
        [SerializeField] Rigidbody2D rocketRigidbody2D;
        //private RocketModuleParams _rocketModuleParams;
        private IRocketModule _curentRocketModule;

        private List<IRocketModule> _rocketModules = new();
        [SerializeField] private List<ModuleConfig> currentModuleConfigs;
        
        private void Start()
        {
            
            _rocketModules = GetComponentsInChildren<IRocketModule>().ToList();
            foreach (var module in _rocketModules)
            {
                
                
                var config = currentModuleConfigs.FirstOrDefault(c => c.ModuleType == module.ModuleType);
                if (config == null)
                {
                    Debug.LogError($"Config for module type {module.ModuleType} not found!");
                    continue;
                }
                var moduleParams = new RocketModuleParams
                {
                    Fuel = config.Fuel,
                    Thurst = config.Thrust,
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