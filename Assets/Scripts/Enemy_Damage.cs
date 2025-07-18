using UnityEngine;
using UnityEngine.Playables;

public class Enemy_Damage : MonoBehaviour
{
    public Transform player;
    public Player_State playerState;
    public Transform enemy;

    public int Hp = 100;
    public int currentHp;

    public int enemyDamage = 10;

    public void Start()
    {
        playerState = FindObjectOfType<Player_State>();
        player = GameObject.FindWithTag("Player").transform;
        enemy = GameObject.FindWithTag("Enemy").transform;

        currentHp = Hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player_Damage>()?.TakeDamage(enemyDamage);
        }
    }

    public void TakeDamage()
    {
        Hp -= playerState.Damage;
        Debug.Log($"{gameObject.name}��(��) {playerState.Damage}�� �������� �޾ҽ��ϴ�. ���� ü��: {Hp}");

        if (Hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name}��(��) ����߽��ϴ�.");

        Destroy(gameObject);
    }
}
