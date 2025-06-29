using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public class CapsuleRocketModule: RocketModuleBase
    {
        private float _currentFuel;

        private Vector2 _force;
        public override ModuleType ModuleType => ModuleType.Capsule;
        public override void Initialize(Rigidbody2D Rocketrigidbody,RocketModuleParams RocketModuleParams)
        {
            _rocketRigidbody2D = Rocketrigidbody;
            _rocketModuleParams = RocketModuleParams;
            _force = _rocketModuleParams.Thurst*Vector2.up;
            _currentFuel = _rocketModuleParams.Fuel;
        }
        

        public override void Move()
        {   
            if (IsDetached) return;
            
            if (_currentFuel > 0)
            {
                _rocketRigidbody2D.AddForce(_force);
                _currentFuel -= Time.fixedDeltaTime * _rocketModuleParams.Thurst;
            }
            else
            {
                Detach();
            }

        }
    }
}