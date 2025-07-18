using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);  // ���� �ð� �� �Ѿ� �ڵ� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Enemy_Bullet �浹�� ��ü �±�: {collision.tag}");

        if (collision.CompareTag("Player"))
        {
            Player_State playerState = collision.GetComponent<Player_State>();
            if (playerState != null)
            {
                Debug.Log("�÷��̾ �����! ������ ���� �õ�.");
                playerState.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("�÷��̾ Player_State ������Ʈ�� �����ϴ�!");
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
