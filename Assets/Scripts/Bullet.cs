using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player_State state;

    public GameObject player;
    float distance;

    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance >= state.intersection)
        {
            Destroy(gameObject, 5);
        }
    }
}