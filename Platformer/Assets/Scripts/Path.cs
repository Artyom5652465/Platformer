using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    public Transform GetNextPoint(ref int numberOfPoint)
    {
        numberOfPoint++;

        return _points[numberOfPoint % _points.Length]; 
    }

    public Transform GetRandomPoint(out int numberOfPoint)
    {
        numberOfPoint = Random.Range(0, _points.Length);

        return _points[numberOfPoint];
    }
}
