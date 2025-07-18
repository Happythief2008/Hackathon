using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player_State state;
    public Transform player;
    public Transform Enemy;

    public GameObject shooter;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Enemy = GameObject.FindWithTag("Enemy").transform;
    }

    void Update()
    {
        if (shooter == null)
        {
            Debug.LogWarning("Bullet�� shooter�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }

        if (state == null)
        {
            Debug.LogWarning("Bullet: state�� �Ҵ���� �ʾҽ��ϴ�!");
        }

        float distance = Vector2.Distance(shooter.transform.position, transform.position);

        if (distance >= state.intersection)
        {
            Destroy(gameObject);
        }

    }

    public void SetState(Player_State playerState)
    {
        state = playerState;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && shooter.CompareTag("Player"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(state.Damage);
            }
            Destroy(gameObject);
        }

        // Player �¾��� ��
        else if (other.CompareTag("Player") && shooter.CompareTag("Enemy"))
        {
            Player_Damage player = other.GetComponent<Player_Damage>();
            if (player != null)
            {
                player.TakeDamage(Enemy_Damage.enemyDamage);
            }
            Destroy(gameObject);
        }

        // �ڱ� �ڽ� ���� ��� ���� (�ɼ�)
        else if (other.gameObject == shooter)
        {
            return;
        }
    }
}