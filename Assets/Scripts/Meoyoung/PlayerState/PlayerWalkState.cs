using UnityEngine;

public class PlayerWalkState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Rigidbody _rb;
    private float _speed;
    private Vector3 _direction;

    public void OnStateEnter(PlayerController npcController)
    {
        Debug.Log("PlayerController : WalkState 진입");

        if (!_playerController)
            _playerController = npcController;
        _rb = _playerController._rigidbody;
        _speed = _playerController.walkSpeed;
    }
    public void OnStateUpdate()
    {
        _direction = new(_playerController.movement.x, 0, _playerController.movement.y);

        if (_direction != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
        }
        else
        {
            _playerController.ChangeState(_playerController._idleState);
        }
    }

    public void OnStateExit()
    {

    }
}
