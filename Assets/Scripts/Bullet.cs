using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player_State state;
    public Enemy_Damage ED;
    public GameObject player;
    public Transform enemy;

    public GameObject shooter;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy").transform;
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
            if (enemy != null)
            {
                ED.TakeDamage();
            }
            Destroy(gameObject);
        }

        // Player �¾��� ��
        else if (other.CompareTag("Player") && shooter.CompareTag("Enemy"))
        {
            Player_Damage player = other.GetComponent<Player_Damage>();
            if (player != null)
            {
                player.TakeDamage(ED.enemyDamage);
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