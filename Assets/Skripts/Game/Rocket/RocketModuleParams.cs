using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct RocketModuleParams
    {
        public int RocketModuleID;
        public GameObject RocketModule;
        public float fuel;
        public float thrust;
    }
}