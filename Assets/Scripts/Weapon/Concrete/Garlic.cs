using UnityEngine;

namespace Weapon
{
    public class Garlic : Weapon
    {
        protected override void Start()
        {
            base.Start();
            GameObject spawnedGarlic = Instantiate(weaponData.SpawnedWeapon, transform, true);
            spawnedGarlic.transform.position = transform.position; 
        }
        protected override void Attack()
        {
            base.Attack();
    
        }
    }
}