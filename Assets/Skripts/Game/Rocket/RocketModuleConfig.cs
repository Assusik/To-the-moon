using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Config/RocketModuleConfig", fileName = "RocketModuleConfig")]
   
    public class RocketModuleConfig : ScriptableObject
    {
        public List<RocketModuleParams> EngineRocketModules;
       public List<RocketModuleParams> CapsuleocketModuleList;


       public RocketModuleParams GetModule(int ModuleId,RocketModuleType ModuleType)
       {
           if (ModuleType == RocketModuleType.EngineRocketModuleType)
           {
               foreach (var item in EngineRocketModules)
               {
                   if (item.RocketModuleID == ModuleId)
                   {
                       return item;
                   }

               }

               Debug.LogError($"Not found module with id{ModuleId} with type {ModuleType}");
               
           }
           else
           {
               foreach (var item in CapsuleocketModuleList)
               {
                   if (item.RocketModuleID == ModuleId)
                   {
                       return item;
                   }
               }
               Debug.LogError($"Not found module with id{ModuleId} with type {ModuleType}");
               
           }
           return default;
       }
    }

    public enum RocketModuleType
    {
        CapsuleRocketModuleType,
        EngineRocketModuleType
    }
}