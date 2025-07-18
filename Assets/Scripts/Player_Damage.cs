using UnityEngine;
using System.Collections;

public class Player_Damage : MonoBehaviour
{
    Player_State state;

    void Start()
    {
        state = GetComponent<Player_State>();
    }

    public void TakeDamage(int Damage)
    {
        state.Hp -= Damage;
        Debug.Log($"{gameObject.name}��(��) {Damage}�� �������� �޾ҽ��ϴ�. ���� ü��: {state.Hp}");

        if (state.Hp <= 0)
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
