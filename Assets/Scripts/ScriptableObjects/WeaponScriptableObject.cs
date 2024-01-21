using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        [SerializeField] private GameObject spawnedWeapon;
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float cooldownDuration;
        public GameObject SpawnedWeapon => spawnedWeapon;
        
        public float Damage => damage;
        public float Speed => speed; 
        public float CooldownDuration => cooldownDuration;
    }
}