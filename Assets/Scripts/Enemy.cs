using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    [SerializeField] private float recognizeDistance = 10f;   // 인식 거리
    [SerializeField] private float attackDistance = 5f;       // 사거리

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float shootCooldown = 2f;  // 쏘고 나서 재사용 대기시간
    private float shootTimer = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player 태그가 붙은 오브젝트를 찾을 수 없습니다!");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= recognizeDistance)
        {
            // 플레이어 방향 바라보기 (2D Z축 회전 기준)
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

            if (distance <= attackDistance)
            {
                // 사거리 안이면 공격
                shootTimer += Time.deltaTime;
                if (shootTimer >= shootCooldown)
                {
                    Shoot(direction);
                    shootTimer = 0f;
                }
            }
            else
            {
                // 사거리 밖이면 플레이어 쪽으로 이동 (원하면)
                Vector3 moveDir = new Vector3(direction.x, direction.y, 0f);
                transform.position += moveDir * speed * Time.deltaTime;
            }
        }
    }

    void Shoot(Vector3 direction)
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("총알 프리팹이나 발사 위치가 설정되지 않았습니다!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // 총알 방향 맞춤 (2D 회전 Z축 기준)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Rigidbody2D를 사용해 직선으로 이동시키기
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float bulletSpeed = 10f;  // 총알 속도
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
