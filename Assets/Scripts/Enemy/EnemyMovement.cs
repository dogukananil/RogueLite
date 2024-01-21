using Managers;
using ScriptableObjects;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyController;
        private PlayerController _player;
        

        void Start()
        {
            _player = GameManager.Instance.playerController;
        }
        void Update()
        {
            MoveToPlayer();
            LookAtPlayer();
        }
        private void MoveToPlayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, enemyController.enemyData.MoveSpeed * Time.deltaTime);
        }
        private void LookAtPlayer()
        {
            Vector3 look = transform.InverseTransformPoint(_player.transform.position);
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

            transform.Rotate(0, 0, angle - 90);
        }
    }
}