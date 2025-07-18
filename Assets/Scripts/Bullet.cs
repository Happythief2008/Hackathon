using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player_State state;
    public GameObject player;

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Bullet�� player�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }

        if (state == null)
        {
            Debug.LogWarning("Bullet: state�� �Ҵ���� �ʾҽ��ϴ�!");
        }

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance >= state.intersection)
        {
            Destroy(gameObject);
        }

    }

    public void SetState(Player_State playerState)
    {
        state = playerState;
    }
}