using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected float _currentHealth;
    protected float _maxHealth;

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(float amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
    }
}
