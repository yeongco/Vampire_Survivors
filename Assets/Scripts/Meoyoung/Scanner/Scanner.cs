using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [Tooltip("자동공격 인식 범위")]
    [SerializeField] float scanRange;

    [Tooltip("자동공격할 대상의 Layer")]
    [SerializeField] LayerMask targetLayer;

    [Tooltip("자동공격을 인식하기 위한 Enemy의 Collider")]
    [SerializeField] Collider[] targets;

    [Tooltip("가장 가까운 적")]
    [SerializeField] Transform nearestTarget;

    private void FixedUpdate()
    {
        //캐스팅 시작 위치, 원의 반지름, 캐스팅 방향(방향 없이 모든 범위를 인지할 것이기때문에 zero), 캐스팅 길이, 대상 레이어
        targets = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
        nearestTarget = GetNearest();
        /*if(nearestTarget != null )
            Debug.Log("가장 가까운 적 : " + nearestTarget.name);*/
    }


    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach(Collider target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos); //나와 target 사이의 거리를 구해줌

            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}
