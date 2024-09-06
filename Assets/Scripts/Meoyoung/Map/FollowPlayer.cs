using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("따라갈 부모 오브젝트")]
    [SerializeField] Transform parentTransform;

    void Update()
    {
        // 부모의 위치를 따라가되, 회전은 적용하지 않음
        transform.position = parentTransform.position;
    }
}
