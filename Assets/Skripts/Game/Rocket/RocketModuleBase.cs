using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public abstract class RocketModuleBase : MonoBehaviour, IRocketModule
    {
        
        protected bool IsDetached { get; set; }
        public abstract ModuleType ModuleType { get; }
        public event UnityAction OnDetach;
        public event UnityAction<float> OnFuelChanged;
        
        protected Rigidbody2D _rocketRigidbody2D;
        protected RocketModuleParams _rocketModuleParams;
        public virtual void Initialize(Rigidbody2D rocketRigidbody2D, RocketModuleParams RocketModuleParams)
        {
            _rocketRigidbody2D = rocketRigidbody2D;
            _rocketModuleParams = RocketModuleParams;
        }

        public abstract void Move();
        public abstract float GetMaxFuel();

        public virtual void Detach()
        {
            if (IsDetached) return;

            IsDetached = true;
            transform.SetParent(null);

            if (GetComponent<Rigidbody2D>() == null)
                gameObject.AddComponent<Rigidbody2D>();

            OnDetach?.Invoke();
        }
    }
}
