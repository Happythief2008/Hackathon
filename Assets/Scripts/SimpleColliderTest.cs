using UnityEngine;

public class SimpleColliderTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} 충돌 감지: {other.gameObject.name}");
    }
}

