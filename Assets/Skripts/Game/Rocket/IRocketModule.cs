using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Game.Rocket
{
    public interface IRocketModule
    {
        
        event UnityAction OnDetach;
        ModuleType ModuleType { get; }
        void Initialize(Rigidbody2D sharedBody, RocketModuleParams parameters);
        void Move();
        float GetMaxFuel();
        void Detach(); // можно убрать из интерфейса и сделать internal
    }
}