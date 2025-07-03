using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public class CapsuleRocketModule: RocketModuleBase
    {
        private float _currentFuel;

        private Vector2 _force;
       [SerializeField] private Transform _rocketModuleForceTransform;
        private Vector2 _enginePosition;
        public override ModuleType ModuleType => ModuleType.Capsule;
        public override void Initialize(Rigidbody2D Rocketrigidbody,RocketModuleParams RocketModuleParams)
        {
            _rocketRigidbody2D = Rocketrigidbody;
            _rocketModuleParams = RocketModuleParams;
            _force = _rocketModuleParams.Thurst*Vector2.up;
            _currentFuel = _rocketModuleParams.Fuel;
            _enginePosition = _rocketModuleForceTransform.localPosition;
            
        }

        public override float GetMaxFuel()
        {
            return _rocketModuleParams.Fuel;
        }


        public override void Move()
        {   
            if (IsDetached) return;
            
            if (_currentFuel > 0)
            {
                _rocketRigidbody2D.AddForceAtPosition(_force, (Vector2)_rocketModuleForceTransform.localPosition);
                _currentFuel -= Time.fixedDeltaTime * _rocketModuleParams.Thurst;
                EventSystem.RaiseFuelChanged(_currentFuel);
                
            }
            else
            {
                Detach();
                
            }

        }
    }
}