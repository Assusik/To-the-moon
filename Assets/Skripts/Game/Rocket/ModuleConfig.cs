using UnityEngine;

namespace Skripts.Game.Rocket
{
    [CreateAssetMenu(fileName = "RocketModuleConfig", menuName = "Configs/RocketModuleConfig")]
    public class ModuleConfig:ScriptableObject
    {
        
            public ModuleType ModuleType;
            public float Fuel;
            public float Thrust;
   
            //public GameObject ModulePrefab;
        
    }
}