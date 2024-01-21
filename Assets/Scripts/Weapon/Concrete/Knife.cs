using Managers;
using UnityEngine;

namespace Weapon
{
    public class Knife : Weapon
    {
        protected override void Start()
        {
            base.Start();
        }
        
        protected override void Attack()
        {
            base.Attack();
            GameObject spawnedKnife = Instantiate(weaponData.SpawnedWeapon);
            spawnedKnife.transform.position = transform.position;
            spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(GameManager.Instance.playerController.playerMovement.lastMoveDirection);
        }
    }
}