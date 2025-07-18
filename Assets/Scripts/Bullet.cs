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
            Debug.LogWarning("Bullet의 player가 할당되지 않았습니다!");
            return;
        }

        if (state == null)
        {
            Debug.LogWarning("Bullet: state가 할당되지 않았습니다!");
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