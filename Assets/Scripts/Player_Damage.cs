using UnityEngine;

public class Player_Damage : MonoBehaviour
{
    Player_State state;
    Animator animator;
    public Transform Enemy;

    void Start()
    {
        state = GetComponent<Player_State>();
        animator = GetComponent<Animator>();
        Enemy = GameObject.FindWithTag("Enemy").transform;
    }

    public void TakeDamage(int Damage)
    {
        state.Hp -= Damage;
        Debug.Log($"{gameObject.name}��(��) {Damage}�� �������� �޾ҽ��ϴ�. ���� ü��: {state.Hp}");

        animator.SetTrigger("Hit");

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
