using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    
    public class EngineRocketModule: RocketModuleBase
    {   
        private Rigidbody2D _rocketRigitRigidbody2D;//поменять название из базового класса!!!   !!!!!!!!!
        
        

        private float _currentFuel;

        private Vector2 _force;


        public override ModuleType ModuleType => ModuleType.Engine;
        
        public override void Initialize(Rigidbody2D Rocketrigidbody,RocketModuleParams RocketModuleParams)
        {
            _rocketRigitRigidbody2D = Rocketrigidbody;
            _rocketModuleParams = RocketModuleParams;
            _force = _rocketModuleParams.Thurst*Vector2.up;
            _currentFuel = _rocketModuleParams.Fuel;



        }

        public override void Move()
        {
            
            if (IsDetached) return;
            
            if (_currentFuel > 0)
            {
                _rocketRigitRigidbody2D.AddRelativeForce(_force);
                _currentFuel -= Time.fixedDeltaTime * _rocketModuleParams.Thurst;
                EventSystem.RaiseFuelChanged(_currentFuel);
            }
            else
            {
                Detach();
            }

        }

        public override float GetMaxFuel()
        {
            return _rocketModuleParams.Fuel;
        }
    }
}