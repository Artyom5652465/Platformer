using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FillBarReenderer _fillBarReenderer;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Start()
    {
        _fillBarReenderer.SetMaxHealth(_maxHealth, _currentHealth);
    }

    public void TakeDamage(int takenDamage)
    {
        _currentHealth -= takenDamage;

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        _fillBarReenderer.SetCurrentHealth(_currentHealth);
    }
}
