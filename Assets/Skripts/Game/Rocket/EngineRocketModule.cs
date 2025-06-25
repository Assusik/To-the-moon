using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class EngineRocketModule:MonoBehaviour,IRocketModule
    {
        
        private int _fuel = 10;
        private float _thurst = 10f;
        private RocketController _rocketController;
        

        public event UnityAction OnMissFuel;

        public void Initialize(RocketController rocketController)
        {
            
        }

        public void TurnOn()
        {
            
        }

        public void TurnOff()
        {
            
        }
        

        
    }
}