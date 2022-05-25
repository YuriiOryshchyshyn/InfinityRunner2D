using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _healthDisplay;

    private void Awake()
    {
        _healthDisplay = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.HealthChangeEvent += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChangeEvent -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthDisplay.text = health.ToString();
    }
}
