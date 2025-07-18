using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 30;              // 초기 체력

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0) Destroy(gameObject);
    }
}
