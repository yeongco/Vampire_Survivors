using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Tooltip("카메라가 따라가야할 대상")]
    [SerializeField] Transform target;

    [Tooltip("카메라 위치 보정값")]
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
        //카메라의 포지션을 타겟의 포지션의 offset을 더한만큼 이동
        //카메라의 회전값은 수동으로 설정해줘야함
    }

}
