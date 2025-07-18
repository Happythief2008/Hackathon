using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);  // 일정 시간 후 총알 자동 삭제
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Enemy_Bullet 충돌한 객체 태그: {collision.tag}");

        if (collision.CompareTag("Player"))
        {
            Player_State playerState = collision.GetComponent<Player_State>();
            if (playerState != null)
            {
                Debug.Log("플레이어를 맞췄다! 데미지 적용 시도.");
                playerState.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("플레이어에 Player_State 컴포넌트가 없습니다!");
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
