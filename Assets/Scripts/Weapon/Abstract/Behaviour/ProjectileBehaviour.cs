using Enemy;
using ScriptableObjects;
using UnityEngine;

namespace Weapon
{
    public abstract class ProjectileBehaviour : MonoBehaviour
    {
        protected Vector3 direction;
        public WeaponScriptableObject weaponData;

        public float destroyAfterSeconds;
        
        protected float currentDamage;
        protected float currentSpeed;
        protected float currentCooldownDuration;
        
        void Awake()
        {
            currentDamage = weaponData.Damage;
            currentSpeed = weaponData.Speed;
            currentCooldownDuration = weaponData.CooldownDuration;
        }
        protected virtual void Start()
        {
            Destroy(gameObject, destroyAfterSeconds);
        }
        public void DirectionChecker(Vector3 dir)
        {
            direction = dir;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 rotation = new Vector3(0, 0, -(-angle + 90));
            transform.rotation = Quaternion.Euler(rotation);
        }
        
        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Enemy"))
            {
                Debug.Log("Hit with Knife");
                EnemyController enemy = col.GetComponent<EnemyController>();
                enemy.TakeDamage(currentDamage);
                Destroy(gameObject);
            }
        }
    }
}