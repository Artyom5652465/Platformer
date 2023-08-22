using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _countRepeats;
    [SerializeField] private int _pause;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Path _path;

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
        int numberOfPoint;
        Transform pointTransform = _path.GetRandomPoint(out numberOfPoint);
        EnemyMovement enemy = Instantiate(_enemyMovement, pointTransform.position, Quaternion.identity);
        
        enemy.SetPath(_path);
        enemy.SetTargetPoint(_path.GetNextPoint(ref numberOfPoint), numberOfPoint);
    }
}
