using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("적이 이동할 속도")]
    [SerializeField] float speed;

    [Tooltip("적의 회전 속도")]
    [SerializeField] float rotationSpeed = 1f;

    [Tooltip("적이 추적할 플레이어")]
    [SerializeField] Rigidbody target;

    private bool isLive;
    private Rigidbody rigid;

    private void Awake()
    {
        isLive = true;
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isLive)
        {
            //플레이어 방향으로 천천히 회전
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            //플레이어 방향으로 이동
            Vector3 dirVec = target.position - rigid.position;
            dirVec.y = 0f;
            Vector3 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector3.zero;
        }
        else
        {
            return;
        }
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody>();
    }

}
