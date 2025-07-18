using UnityEngine;

public class Player_State : MonoBehaviour
{
    public int Hp = 10;
    public int Damage = 10;
    public float shootingSpeed = 30; // 총알 속도
    public float shootingCooltime = 0.3f; // 공격 속도
    public float intersection = 10; // 사거리
    public float dashspeed = 10;
    public float dashcoolTime = 0.3f;
    public float dashInvincibilityTime = 0;
    public float PlayerMoveSpeed = 9;
    public float jumpPower = 7;
    public int jumpCnt = 0;
    public bool fire = false;
    public int fireDamage = 0;
    public int Knockback = 0;
    public int Wonhon = 0;

    void Awake()
    {
    }

    // 플레이어가 데미지를 입을 때 호출하는 함수
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        Debug.Log($"플레이어가 {damage} 데미지를 입었습니다. 남은 체력: {Hp}");

        if (Hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("플레이어가 사망했습니다.");
        // 사망 처리: 게임 오버 UI, 리스폰 등
    }
}
