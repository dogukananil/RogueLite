using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Weapon Stats")] public WeaponScriptableObject weaponData;
     
        private float _currentCooldown;

        protected virtual void Start()
        {
            _currentCooldown = weaponData.CooldownDuration;
        }

        protected virtual void Update()
        {
            _currentCooldown -= Time.deltaTime;
            if (_currentCooldown <= 0f)
            {
                Attack();
            }
        }

        protected virtual void Attack()
        {
            _currentCooldown = weaponData.CooldownDuration;
        }
    }
}