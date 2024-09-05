using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Tooltip("적이 이동할 속도")]
    [SerializeField] float speed;

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
            Vector3 dirVec = target.position - rigid.position;
            Vector3 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            transform.LookAt(target.transform);
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
