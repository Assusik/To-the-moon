using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RocketController:MonoBehaviour
    {
       // private void DetachModule()
        
       private Rigidbody2D _rigidbody2D;
       private void Awake()
       {
           _rigidbody2D = GetComponent<Rigidbody2D>();
       }

       public void Initialize(IRocketModule rocketModule)
       {
           
       }
       
       

       private void Update()
       {
           _rigidbody2D.MovePosition(_rigidbody2D.position + _rigidbody2D.velocity * Time.deltaTime);
       }
    }
}