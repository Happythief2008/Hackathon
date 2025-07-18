using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player_State state;
    public GameObject shooter;  // 누가 쏘았는지 저장

    private void Update()
    {
        if (shooter == null)
        {
            Debug.LogWarning("Bullet의 shooter가 할당되지 않았습니다!");
            Destroy(gameObject);  // shooter가 없으면 총알 삭제
            return;
        }

        // 일정 거리 이상 날아가면 삭제 (거리 제한 필요하면 사용)
        float distance = Vector2.Distance(shooter.transform.position, transform.position);
        if (distance >= state.intersection)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 자기 자신이나 자기 자신과 같은 태그인 오브젝트와 충돌 무시
        if (other.gameObject == shooter)
            return;

        // 적에 맞았을 때
        if (other.CompareTag("Enemy") && shooter.CompareTag("Player"))
        {
            Enemy_Damage enemyDamage = other.GetComponent<Enemy_Damage>();
            if (enemyDamage != null)
            {
                enemyDamage.TakeDamage();  // 플레이어 공격력 만큼 데미지 주기
            }

            Destroy(gameObject);  // 총알 파괴
        }

        // 적이 쏜 총알이 플레이어에 맞았을 때 (필요하면)
        else if (other.CompareTag("Player") && shooter.CompareTag("Enemy"))
        {
            Player_Damage playerDamage = other.GetComponent<Player_Damage>();
            if (playerDamage != null)
            {
                playerDamage.TakeDamage(state.Damage);  // 적 공격력으로 데미지 주기 (조정 필요)
            }

            Destroy(gameObject);
        }
    }
}
