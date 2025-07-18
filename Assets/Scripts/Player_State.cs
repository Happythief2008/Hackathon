using UnityEngine;

public class Player_State : MonoBehaviour
{
    public int Hp = 1000;
    public int Damage = 10;
    public float shootingSpeed = 30; // �Ѿ� �ӵ�
    public float shootingCooltime = 0.3f; // ���� �ӵ�
    public float intersection = 10; // ��Ÿ�
    public float dashspeed = 10; 
    public float dashcoolTime = 0.3f;
    public float dashInvincibilityTime = 0;
    public float PlayerMoveSpeed = 9;
    public float jumpPower = 7;
    public int jumpCnt = 0;
    public bool fire = false;
    public int fireDamage = 0;
    public int Knockback = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

