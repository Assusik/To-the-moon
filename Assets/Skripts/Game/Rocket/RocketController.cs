using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class RocketController:MonoBehaviour
    {
        
        
        [SerializeField] private RocketModuleConfig _moduleConfig;
        
        [SerializeField] Rigidbody2D _rigidbody2D;
        
        private List<IRocketModule> _rocketModules;
        private IRocketModule _currentRocketModule;
        
        
        private EngineRocketModule _engineRocketModule;
        private CapsuleRocketModule _capsuleRocketModule;


        public void Initialize(EngineRocketModule engineRocketModule, CapsuleRocketModule capsuleRocketModule)
        {
            

            _engineRocketModule.Initialize(_moduleConfig.GetModule(1,RocketModuleType.EngineRocketModuleType),_rigidbody2D); // выбор модуля
            _capsuleRocketModule.Initialize(_moduleConfig.GetModule(1,RocketModuleType.CapsuleRocketModuleType),_rigidbody2D);// выбор капсулы
            _rocketModules = new List<IRocketModule> { _engineRocketModule, _capsuleRocketModule };
            _currentRocketModule = _rocketModules[0];
            _engineRocketModule.OnMissFuel += ChangeCurrentModule;

        }
        private void ChangeCurrentModule()
        {
            if (_rocketModules.Count > 1)
            {
                _rocketModules.RemoveAt(0);
                _currentRocketModule = _rocketModules[0];
            }
        }




    }
}