using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartsBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Hearth _heartTemplate;

    private List<Hearth> _hearts = new List<Hearth>();

    private void OnEnable()
    {
        _player.HealthChangeEvent += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChangeEvent -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int heartsFeeling = value - _hearts.Count;
            for (int i = 0; i < heartsFeeling; i++)
            {
                CreateHeart();
            }
        }
        else if (value < _hearts.Count && _hearts.Count != 0)
        {
            DeleteHeart(_hearts[_hearts.Count - 1]);
        }
    }

    private void CreateHeart()
    {
        Hearth heart = Instantiate(_heartTemplate, transform);
        _hearts.Add(heart);
        heart.ToFill();
    }

    private void DeleteHeart(Hearth heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
