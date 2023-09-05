using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private UnityEvent _startEvent;
    [SerializeField] private UnityEvent _event;

    public event UnityAction Set
    {
        add => _startEvent.AddListener(value);
        remove => _startEvent.RemoveListener(value);
    }

    public event UnityAction Changed
    {
        add => _event.AddListener(value);
        remove => _event.RemoveListener(value);
    }

    private void Start()
    {
        _startEvent.Invoke();
    }

    public void TakeDamage(int health)
    {
        _currentHealth -= health;

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        _event.Invoke();
    }

    public void Heal(int health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        _event.Invoke();
    }

    public int GetCurrentHealth() => _currentHealth;
    public int GetMaxHealth() => _maxHealth;
}
