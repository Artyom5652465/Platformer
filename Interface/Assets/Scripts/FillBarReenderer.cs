using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(Slider))]

public class FillBarReenderer : MonoBehaviour
{
    private Slider _slider;
    private Coroutine _coroutineOfFillingBar;

    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _recoveryRate;
    [SerializeField] private float _finalValue;
    [SerializeField] private Player _player;
 
    private void OnEnable()
    {
        _slider = GetComponent<Slider>();

        _player.Set += SetMaxHealth;
        _player.Changed += SetCurrentHealth;
    }

    private void OnDisable()
    {
        _player.Set -= SetMaxHealth;
    }

    private IEnumerator SetFillBar()
    {
        while (_slider.value != _finalValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _finalValue, _recoveryRate * Time.deltaTime);
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);

            yield return null;
        }
    }

    public void SetMaxHealth()
    {
        _slider.maxValue = _slider.value = _finalValue = _player.GetMaxHealth();
        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetCurrentHealth()
    {
        _finalValue = _player.GetCurrentHealth();

        if(_coroutineOfFillingBar != null)
        {
            StopCoroutine(_coroutineOfFillingBar);
        }

        _coroutineOfFillingBar = StartCoroutine(SetFillBar());
    }
}
