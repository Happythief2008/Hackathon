using UnityEngine;

public class SimpleColliderTest1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($" 총알의 {gameObject.name} 충돌 감지: {other.gameObject.name}");
    }
}

