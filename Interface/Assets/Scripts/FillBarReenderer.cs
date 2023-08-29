using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class FillBarReenderer : MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _recoveryRate;
    [SerializeField] private float _finalValue;

    private void Start()
    {
        _slider = GetComponent<Slider>(); 
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _finalValue, _recoveryRate * Time.deltaTime);
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void SetMaxHealth(int maxHealth, int health)
    {
        _slider.maxValue = maxHealth;
        _slider.value = health;
        _finalValue = health;
        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetCurrentHealth(int health)
    {
        _finalValue = health;        
    }
}
