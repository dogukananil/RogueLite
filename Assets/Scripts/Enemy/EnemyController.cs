using ScriptableObjects;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public EnemyScriptableObject enemyData;
        
        private float _currentMoveSpeed;
        private float _currentHealth;
        private float _currentDamage;

        void Awake()
        {
            _currentMoveSpeed = enemyData.MoveSpeed;
            _currentHealth = enemyData.MaxHealth;
            _currentDamage = enemyData.Damage;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            Destroy(gameObject);
        }
    }
}
