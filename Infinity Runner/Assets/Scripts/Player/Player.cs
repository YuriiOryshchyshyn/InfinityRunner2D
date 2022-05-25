using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChangeEvent;
    public event UnityAction DieEvent;

    private void Start()
    {
        HealthChangeEvent?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChangeEvent?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        DieEvent?.Invoke();
    }
}
