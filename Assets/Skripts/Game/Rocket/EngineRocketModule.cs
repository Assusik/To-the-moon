using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    
    public class EngineRocketModule: RocketModuleBase
    {   
        private Rigidbody2D _rocketRigitRigidbody2D;//поменять название из базового класса!!!   !!!!!!!!!
        
        

        private float _currentFuel;

        private Vector2 _force;

        [SerializeField] Transform _rocketModuleForceTransform;
        private Vector2 _enginePosition;
        public override ModuleType ModuleType => ModuleType.Engine;
        
        public override void Initialize(Rigidbody2D Rocketrigidbody,RocketModuleParams RocketModuleParams)
        {
            _rocketRigitRigidbody2D = Rocketrigidbody;
            _rocketModuleParams = RocketModuleParams;
            _force = _rocketModuleParams.Thurst*Vector2.up;
            _currentFuel = _rocketModuleParams.Fuel;
            _enginePosition = _rocketModuleForceTransform.localPosition;


        }

        public override void Move()
        {
            
            if (IsDetached) return;
            
            if (_currentFuel > 0)
            {
                _rocketRigitRigidbody2D.AddForceAtPosition(_force, (Vector2)_rocketModuleForceTransform.localPosition);
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