using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class CapsuleRocketModule:MonoBehaviour,IRocketModule
    {

        private float _fuel;
        private float _thurst;
        private Rigidbody2D _rocketRigidbody2D;
        private RocketController _rocketController;
        private bool _turnOn = true;
        private float _fuelConsumption;
        

        public event UnityAction OnMissFuel;

        public void Initialize(RocketModuleParams rocketModuleParams ,Rigidbody2D rigidbody2D)
        {
            _fuel = rocketModuleParams.fuel;
            _thurst = rocketModuleParams.thrust;
            _rocketRigidbody2D = rigidbody2D;
            OnMissFuel += Detach;
        }

        public void Detach()
        {
            transform.SetParent(null);
            TurnOff();
        }

        private void FixedUpdate()
        {
            if (_turnOn)
            {
                Vector2 force = Vector2.zero * _thurst;
                _rocketRigidbody2D.AddForce(force);
                if (_fuel >= 0)
                {
                    _fuel -= _fuelConsumption * Time.fixedDeltaTime;
                }
                else
                {
                    OnMissFuel?.Invoke();
                }
            }


        }

        public void TurnOn()
        {
            _turnOn = true;
        }

        public void TurnOff()
        {
            _turnOn = false;
        }
        

        
    }
}