using System.Collections;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private int _countRepeats;
    [SerializeField] private float _radius;
    [SerializeField] private int _pause;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        StartCoroutine(MakePause());
    }

    private IEnumerator MakePause()
    {
        for (int i = 0; i < _countRepeats; i++)
        {
            yield return new WaitForSeconds(_pause);

            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(_coin, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x + Random.Range(-_radius, _radius), transform.position.y, transform.position.z + Random.Range(-_radius, _radius));
    }
}
