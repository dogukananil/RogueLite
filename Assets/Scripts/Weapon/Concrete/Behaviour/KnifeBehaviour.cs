using System;
using Enemy;
using Managers;
using UnityEngine;

namespace Weapon
{
    public class KnifeBehaviour : ProjectileBehaviour
    {
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            transform.position += direction * (currentSpeed * Time.deltaTime);
        }
        
    }
}