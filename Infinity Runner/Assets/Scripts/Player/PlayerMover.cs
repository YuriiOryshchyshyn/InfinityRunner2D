using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _maxYPosition;
    [SerializeField] private float _minYPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _stepDistance;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (transform.position.y < _maxYPosition)
            SetNextPosition(_stepDistance);
    }
    public void TryMoveDown()
    {
        if (transform.position.y > _minYPosition)
            SetNextPosition(-_stepDistance);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x, transform.position.y + stepSize);
    }
}
