using System;
using System.Collections;
using Enemy;
using ScriptableObjects;
using UnityEngine;

namespace Weapon
{
    public abstract class MeleeWeaponBehaviour : MonoBehaviour
    {
        public WeaponScriptableObject weaponData;
        private SpriteRenderer spriteRenderer;
        
        private float _currentDamage;
        private float _currentCoolDownDuration;
        private float _currentSpeed;
       
        private float _time;
        private bool _canAttack;
        private bool _isClosed;

        void Awake()
        {
            _currentDamage = weaponData.Damage;
            _currentCoolDownDuration = weaponData.CooldownDuration;
            _currentSpeed = weaponData.Speed;
        }

        protected virtual void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(OpenAndClose());
        }

        protected void Update()
        {
            AttackFrequency();
        }

        private IEnumerator OpenAndClose()
        {
            while (true)
            {
                Open();
                yield return new WaitForSeconds(_currentCoolDownDuration);

                Close();
                yield return new WaitForSeconds(_currentCoolDownDuration);
            }
        }

        private void Open()
        {
            _currentDamage = weaponData.Damage;
            Color spriteRendererColor = spriteRenderer.color;
            spriteRendererColor.a = 1f;
            spriteRenderer.color = spriteRendererColor;
            _isClosed = false;
            _canAttack = true;
        }

        private void Close()
        {
            Color spriteRendererColor = spriteRenderer.color;
            spriteRendererColor.a = 0f;
            spriteRenderer.color = spriteRendererColor;
            _canAttack = false;
            _isClosed = true;
        }

        protected virtual void OnTriggerStay2D(Collider2D col)
        {
            if (!_canAttack)
            {
                return;
            }
            if (col.CompareTag("Enemy"))
            {
                Debug.Log("Hit with Garlic");
                EnemyController enemy = col.GetComponent<EnemyController>();
                enemy.TakeDamage(_currentDamage);
                _canAttack = false;
            }
        }

        private void AttackFrequency()
        {
            if(_isClosed)return;
            _time -= Time.deltaTime;

            if (_time <= 0f)
            {
                _time = _currentSpeed;
                _canAttack = true;
            }
        }
    }
}