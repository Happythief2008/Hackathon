using UnityEngine;

public class Player_State : MonoBehaviour
{
    public int Hp = 0;
    public int Damage = 0;
    public int shootingSpeed = 5; // 총알 속도
    public int shootingCooltime = 1; // 공격 속도
    public int intersection = 3; // 사거리
    public int DashSpeed = 0;
}
