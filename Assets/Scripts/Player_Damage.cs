using UnityEngine;
using System.Collections;

public class Player_Damage : MonoBehaviour
{
    Player_State state;
    public Transform Enemy;

    void Start()
    {
        state = GetComponent<Player_State>();
        Enemy = GameObject.FindWithTag("Enemy").transform;
    }

    public void TakeDamage(int Damage)
    {
        state.Hp -= Damage;
        Debug.Log($"{gameObject.name}이(가) {Damage}의 데미지를 받았습니다. 현재 체력: {state.Hp}");

        if (state.Hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name}이(가) 사망했습니다.");

        Destroy(gameObject);
    }
}
