using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    private float fixedY; // ī�޶� Y ������

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Ÿ���� �������� �ʾҽ��ϴ�.");
            return;
        }

        fixedY = transform.position.y; // ���� ī�޶� Y�� ����
    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(
            target.position.x,
            fixedY,
            transform.position.z // Z�� �Ϲ������� -10
        );
    }
}