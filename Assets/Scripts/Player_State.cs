using UnityEngine;

public class Player_State : MonoBehaviour
{
    public int Hp = 1000;
    public int Damage = 10;
    public float shootingSpeed = 5; // �Ѿ� �ӵ�
    public float shootingCooltime = 0.5f; // ���� �ӵ�
    public float intersection = 0; // ��Ÿ�
    public float DashSpeed = 10; 
    public float DashCoolTime = 0.3f;
    public float PlayerMoveSpeed = 5;
}
