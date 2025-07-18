using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;          // 따라갈 대상 (플레이어)
    private Vector3 offset;           // 초기 카메라‑플레이어 간 거리

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraController: 타겟이 지정되지 않았습니다.");
            enabled = false;          // 더 이상 업데이트하지 않도록 비활성화
            return;
        }

        // 처음 씬에 배치된 카메라와 플레이어 간의 상대 거리 기억
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // 안전장치
        if (target == null) return;

        // X, Y 모두 따라가고 Z는 원래 값 유지
        transform.position = target.position + offset;
    }
}
