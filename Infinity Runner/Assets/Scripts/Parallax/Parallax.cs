using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        if (_imagePositionX > 1)
            _imagePositionX = 0;

        _imagePositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
