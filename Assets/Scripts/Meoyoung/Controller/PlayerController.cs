using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Rigidbody")]
    [Tooltip("캐릭터의 움직임을 제어하는 컴포넌트")]
    public Rigidbody _rigidbody;

    [Header("Movement")]
    public Vector2 movement; //플레이어가 바라보는 방향
    public float walkSpeed = 1f; //플레이어가 걷는 속도


    public static PlayerController Instance { get; private set; } // Singleton 인스턴스


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 전환되어도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있다면 새로 생성된 것을 파괴
        }
    }

    public IPlayerState CurrentState
    {
        get; set;
    }

    public Vector2 CurrentDirection
    {
        get; set;
    }

    public IPlayerState _idleState, _walkState;


    private void Start()
    {
        _idleState = gameObject.AddComponent<PlayerIdleState>();
        _walkState = gameObject.AddComponent<PlayerWalkState>();

        if(_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();

        ChangeState(_idleState);
    }

    private void Update()
    {
        UpdateState();
    }

    public void ChangeState(IPlayerState playerState)
    {
        if (CurrentState != null)
            CurrentState.OnStateExit();
        CurrentState = playerState;
        CurrentState.OnStateEnter(this);
    }

    public void UpdateState()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateUpdate();
        }
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
