using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _MaxSpeed;
    [SerializeField] private float _pause;
    [SerializeField] private Path _path;

    private Transform _point;
    private Animator _animator;
    private int _numberOfTargetPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(MakePause());
    }

    private IEnumerator MakePause()
    {
        yield return new WaitForSeconds(_pause);

        _speed = _MaxSpeed;
    }
    

    private void Update()
    {
        int maxLength = 1;

        transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);
       
        _animator.SetFloat("Speed", Vector3.ClampMagnitude(transform.position, maxLength).magnitude);

        if (transform.position == _point.position)
        {
           _point = _path.GetNextPoint(ref _numberOfTargetPoint);
        }
    }

    public void SetTargetPoint(Transform point, int numberOfTargetPoint)
    {
        _point = point;
        _numberOfTargetPoint = numberOfTargetPoint;
    }

    public void SetPath(Path path) => _path = path;
}
