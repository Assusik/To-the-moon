using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public class CapsuleRocketModule: RocketModuleBase,IRocketModule
    {
       
        private Rigidbody2D _rocketRigitRigidbody2D;
        private RocketModuleParams _rocketModuleParams;

        public bool IsDetached { get; set; }
        public event UnityAction OnDetach;

        private float _currentFuel;

        private Vector2 _force;
        public void Initialize(Rigidbody2D Rocketrigidbody,RocketModuleParams RocketModuleParams)
        {
            _rocketRigitRigidbody2D = Rocketrigidbody;
            _rocketModuleParams = RocketModuleParams;
            _force = _rocketModuleParams.Thurst*Vector2.up;
            _currentFuel = _rocketModuleParams.Fuel;
        }
        public void Detach()
        {
            if (IsDetached) return;
            IsDetached = true;
            
            
            transform.SetParent(null);
            if (GetComponent<Rigidbody2D>() == null)
                gameObject.AddComponent<Rigidbody2D>();

            OnDetach?.Invoke();
        }

        public override void Move()
        {
            if (IsDetached) return;
            
            if (_currentFuel > 0)
            {
                _rocketRigitRigidbody2D.AddForce(_force);
                _currentFuel -= Time.fixedDeltaTime * _rocketModuleParams.Thurst;
            }
            else
            {
                Detach();
            }

        }
    }
}