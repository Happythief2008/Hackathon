using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player_State state;

    public GameObject player;

    void Start()
    {
        float x = transform.position.x - player.transform.position.x;
        float y = transform.position.y - player.transform.position.y;

        if (GetComponent<Rigidbody>() != null)
        {
            Destroy(gameObject, 5);
        }
    }
}