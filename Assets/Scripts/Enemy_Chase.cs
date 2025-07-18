using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Enemy_Chase : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 3f;

    [Header("공격")]
    public int contactDamage = 20;
    public float attackCooldown = 0.5f;

    private Transform player;
    private Rigidbody2D rb;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null)
            Debug.LogWarning("Player 태그가 달린 오브젝트를 찾지 못했습니다.");

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;   // 중력 제거
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // 좌우 방향만 따라감
        float directionX = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(directionX * moveSpeed, 0f);
    }

    /* 플레이어 접촉 시 데미지 */
    void OnCollisionEnter2D(Collision2D col) => TryDamagePlayer(col.collider);
    void OnCollisionStay2D(Collision2D col) => TryDamagePlayer(col.collider);
    void OnTriggerEnter2D(Collider2D col) => TryDamagePlayer(col);
    void OnTriggerStay2D(Collider2D col) => TryDamagePlayer(col);

    void TryDamagePlayer(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        if (Time.time - lastAttackTime < attackCooldown) return;

        Player_Damage pd = col.GetComponent<Player_Damage>();
        if (pd != null)
        {
            pd.TakeDamage(contactDamage);
            lastAttackTime = Time.time;
        }
    }
}
