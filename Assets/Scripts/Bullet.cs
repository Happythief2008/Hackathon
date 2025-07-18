using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;          // 한 발당 데미지
    public float speed = 12f;        // 발사 속도
    public Vector2 direction = Vector2.right; // 발사 방향 (외부에서 지정)

    void Start()
    {
        // 지정된 방향으로 발사
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        Destroy(gameObject, 3f); // 수명 제한
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        EnemyHealth eh = other.GetComponent<EnemyHealth>();
        if (eh != null)
            eh.TakeDamage(damage);

        Destroy(gameObject);
    }
}
