using UnityEngine;

public class SimpleColliderTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} �浹 ����: {other.gameObject.name}");
    }
}

