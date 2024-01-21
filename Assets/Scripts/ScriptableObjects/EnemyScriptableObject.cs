using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxHealth;
        [SerializeField] private float damage;
        
        public float MoveSpeed => moveSpeed;
        public float MaxHealth => maxHealth; 
        public float Damage => damage;
    }
}