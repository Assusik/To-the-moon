using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public abstract class RocketModuleBase : MonoBehaviour, IRocketModule
    {
        public bool IsDetached { get; set; }
        public event UnityAction OnDetach;
        protected Rigidbody2D _rocketRigidbody2D;
        protected RocketModuleParams _rocketModuleParams;
        public void Initialize(Rigidbody2D rocketRigidbody2D, RocketModuleParams RocketModuleParams)
        {
            _rocketRigidbody2D = rocketRigidbody2D;
            _rocketModuleParams = RocketModuleParams;
        }

        public abstract void Move();

        public void Detach()
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
