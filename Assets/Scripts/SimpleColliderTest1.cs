using UnityEngine;

public class SimpleColliderTest1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($" �Ѿ��� {gameObject.name} �浹 ����: {other.gameObject.name}");
    }
}

