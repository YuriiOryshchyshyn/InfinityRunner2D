using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _playerMover.TryMoveUp();
        
        if (Input.GetKey(KeyCode.S))
            _playerMover.TryMoveDown();
    }
}
