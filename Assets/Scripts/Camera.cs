using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (플레이어)
    private float fixedY; // 카메라 Y 고정값

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: 타겟이 지정되지 않았습니다.");
            return;
        }

        fixedY = transform.position.y; // 현재 카메라 Y값 고정
    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(
            target.position.x,
            fixedY,
            transform.position.z // Z는 일반적으로 -10
        );
    }
}