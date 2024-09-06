using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    private PlayerController _playerController;
    private Vector2 _direction;

    public void OnStateEnter(PlayerController npcController)
    {
        //Debug.Log("PlayerController : Idle State 진입");

        if (!_playerController)
            _playerController = npcController;
    }
    public void OnStateUpdate()
    {
        _direction = _playerController.movement;

        if (_direction != Vector2.zero)
        {
            _playerController.ChangeState(_playerController._walkState);
        }
    }

    public void OnStateExit()
    {

    }
}
