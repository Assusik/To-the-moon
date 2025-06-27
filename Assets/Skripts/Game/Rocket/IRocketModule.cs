using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public interface IRocketModule
    {
        bool IsDetached { get; set; }
        event UnityAction OnDetach;
    
        void Initialize(Rigidbody2D sharedBody, RocketModuleParams parameters);
        void Move();
        void Detach(); // можно убрать из интерфейса и сделать internal
    }
}