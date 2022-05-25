using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Hearth : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, Destroy));
    }

    private IEnumerator Filling(float startPosition, float endPosition, UnityAction<float> action)
    {
        float elapsed = 0;
        float nextPosition;

        while (elapsed <= _duration)
        {
            nextPosition = Mathf.Lerp(startPosition, endPosition, elapsed / _duration);
            _image.fillAmount = nextPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
        action?.Invoke(endPosition);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }
}
