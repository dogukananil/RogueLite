using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private SpriteRenderer spriteRenderer;
        public float moveSpeed;

        [HideInInspector] public Vector2 moveDirection;
        [HideInInspector] public Vector2 lastMoveDirection = new(1, 0);

        public void GetInput()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;
            if (moveX != 0 || moveY != 0)
            {
                lastMoveDirection = moveDirection;
            }
        }

        public void Move()
        {
            rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        public bool IsPlayerMoving()
        {
            if (moveDirection.x != 0 || moveDirection.y != 0)
            {
                MakeDirectionCheck();
                return true;
            }

            return false;
        }

        private void MakeDirectionCheck()
        {
            if (moveDirection.x == 0)
                return;
            if (moveDirection.x < 0)
            {
                if (spriteRenderer.flipX) return;
                spriteRenderer.flipX = true;
            }
            else
            {
                if (!spriteRenderer.flipX) return;
                spriteRenderer.flipX = false;
            }
        }
    }
}