using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] int _health;

    public void OnHitButtonClick()
    {
        _player.TakeDamage(_health);
    }

    public void OnHealButtonClick()
    {
        _player.TakeDamage(-_health);
    }
}
