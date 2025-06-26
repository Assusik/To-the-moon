using System;
using DefaultNamespace;
using UnityEngine;

public class GameEntryPoint : EntryPoint
{
    [SerializeField]  private RocketController _rocketController;
    [SerializeField] private EngineRocketModule _engineRocketModule;
    [SerializeField] private CapsuleRocketModule _capsuleRocketModule;
    
    
    public override void Run()
    {
        
    }

    private void Awake()
    {
        _rocketController.Initialize(_engineRocketModule, _capsuleRocketModule);
        
    }
    
}